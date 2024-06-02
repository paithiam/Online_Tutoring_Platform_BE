using AutoMapper;
using BbCenter.Dto.Center;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;

namespace BbCenter.Services
{
    public class CenterService : ICenterService
    {
        private readonly IMapper _mapper;
        private readonly ICenterRepositories _centerRepository;

        public CenterService(IMapper mapper, ICenterRepositories centerRepository)
        {
            _mapper = mapper;
            _centerRepository = centerRepository;
        }

        public CenterDto AddCenter(CreateCenterDto centerDto)
        {
            Center center = _centerRepository.GetCenterName(centerDto.CenterName);

            if (center != null)
            {
                throw new ConflictException("The Center name already exists");
            }

            center = _mapper.Map<Center>(centerDto);
            _centerRepository.CreateCenter(center);

            return _mapper.Map<CenterDto>(center);
        }

        public string DeleteCenter(Guid id)
        {
            Center center = _centerRepository.GetCenterById(id) ?? throw new NotFoundException("The Center does not exists");
            _centerRepository.DeleteCenter(center);
            return "Delete successful";
        }

        public List<CenterDto> GetAllCenter()
        {
            List<Center> CenterList = _centerRepository.GetAllCenter();
            return _mapper.Map<List<CenterDto>>(CenterList);
        }

        public CenterDto GetCenterById(Guid id)
        {
            Center Center = _centerRepository.GetCenterById(id) ?? throw new NotFoundException("The Center does not exists");

            return _mapper.Map<CenterDto>(Center);
        }

        public CenterDto UpdateCenter(Guid id, UpdateCenterDto CenterDto)
        {
            _ = _centerRepository.GetCenterById(id) ?? throw new NotFoundException("Center does not exists");


            CenterDto.CenterId = id;

            Center centerUpdate = _mapper.Map<Center>(CenterDto);
            _centerRepository.UpdateCenter(centerUpdate);

            return _mapper.Map<CenterDto>(centerUpdate);
        }
    }
}



