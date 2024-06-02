using AutoMapper;
using BbCenter.Dto.Booking;
using BbCenter.Dto.Participant;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Repositories;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;

namespace BbCenter.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IMapper _mapper;
        private readonly IClassRoomRepositories _classRoomRepositories;
        private readonly IUserRepositories _userRoomRepositories;
        private readonly IParticipantRepositories _participantRepositories;

        public ParticipantService(IMapper mapper, IClassRoomRepositories classRoomRepositories, IUserRepositories userRoomRepositories, IParticipantRepositories participantRepositories)
        {
            _mapper = mapper;
            _classRoomRepositories = classRoomRepositories;
            _userRoomRepositories = userRoomRepositories;
            _participantRepositories = participantRepositories;
        }

        public ParticipantDto AddParticipant(CreateParticipantDto participantDto)
        {
            Participant participant = _mapper.Map<Participant>(participantDto);

            _participantRepositories.CreateParticipant(participant);

            return _mapper.Map<ParticipantDto>(participant);
        }

        public string DeleteParticipant(Guid id)
        {
            Participant participant = _participantRepositories.GetparticipantById(id) ?? throw new NotFoundException("Participant does not exists");
            _participantRepositories.DeleteParticipant(participant);
            return "Delete successful"; ;
        }

        public List<ParticipantDto> GetAllParticipant()
        {
            List<Participant> participantList = _participantRepositories.GetAllparticipant();
            return _mapper.Map<List<ParticipantDto>>(participantList);
        }


        public ParticipantDto GetParticipantById(Guid id)
        {
            Participant participant = _participantRepositories.GetparticipantById(id) ?? throw new NotFoundException("Participant does not exists");
            return _mapper.Map<ParticipantDto>(participant);
        }

        public ParticipantDto GetParticipantByUserId(Guid id)
        {
            Participant participant = _participantRepositories.GetparticipantByUserId(id) ?? throw new NotFoundException("Participant does not exists");
            return _mapper.Map<ParticipantDto>(participant);
        }

        public ParticipantDto UpdateParticipant(Guid id, UpdateParticipantDto participantDto)
        {
            _ = _participantRepositories.GetparticipantById(id) ?? throw new NotFoundException("Participant does not exists");

            participantDto.ParticipantId = id;

            Participant ParticipantToUpdate = _mapper.Map<Participant>(participantDto);
            _participantRepositories.UpdateParticipant(ParticipantToUpdate);

            return _mapper.Map<ParticipantDto>(ParticipantToUpdate);
        }
    }
}
