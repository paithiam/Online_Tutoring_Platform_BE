using AutoMapper;
using BbCenter.Dto.Center;
using BbCenter.Dto.ClassRoom;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;

namespace BbCenter.Services
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepositories _classRoomRepository;

        public ClassRoomService(IMapper mapper, IClassRoomRepositories classRoomRepository)
        {
            _mapper = mapper;
            _classRoomRepository = classRoomRepository;
        }

        public ClassRoomDto AddClassRoom(CreateClassRoomDto classRoomDto)
        {
            ClassRoom classRoom = _classRoomRepository.GetClassRoomName(classRoomDto.ClassName);

            if (classRoom != null)
            {
                throw new ConflictException("The ClassRoom name already exists");
            }

            classRoom = _mapper.Map<ClassRoom>(classRoomDto);
            _classRoomRepository.CreateClassRoom(classRoom);

            return _mapper.Map<ClassRoomDto>(classRoom);
        }

        public string DeleteClassRoom(Guid id)
        {
            ClassRoom classRoom = _classRoomRepository.GetClassRoomById(id) ?? throw new NotFoundException("The ClassRoom does not exists");
            _classRoomRepository.DeleteClassRoom(classRoom);
            return "Delete successful";
        }

        public List<ClassRoomDto> GetAllClassRoom()
        {
            List<ClassRoom> ClassRoomList = _classRoomRepository.GetAllClassRoom();
            return _mapper.Map<List<ClassRoomDto>>(ClassRoomList);
        }

        public List<ClassRoomDto> GetClassRoomByCenterId(Guid id)
        {
            List<ClassRoom> ClassRoomList = _classRoomRepository.GetClassRoomByCenterId(id);
            return _mapper.Map<List<ClassRoomDto>>(ClassRoomList);
        }

        public ClassRoomDto GetClassRoomById(Guid id)
        {
            ClassRoom classRoom = _classRoomRepository.GetClassRoomById(id) ?? throw new NotFoundException("The ClassRoom does not exists");

            return _mapper.Map<ClassRoomDto>(classRoom);
        }

        public ClassRoomDto UpdateClassRoom(Guid id, UpdateClassRoomDto ClassRoomDto)
        {
            _ = _classRoomRepository.GetClassRoomById(id) ?? throw new NotFoundException("ClassRoom does not exists");


            ClassRoomDto.ClassId = id;

            ClassRoom classRoomUpdate = _mapper.Map<ClassRoom>(ClassRoomDto);
            _classRoomRepository.UpdateClassRoom(classRoomUpdate);

            return _mapper.Map<ClassRoomDto>(classRoomUpdate);
        }
    }
}
