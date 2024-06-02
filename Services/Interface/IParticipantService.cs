using BbCenter.Dto.Booking;
using BbCenter.Dto.Participant;

namespace BbCenter.Services.Interface
{
    public interface IParticipantService
    {
        ParticipantDto AddParticipant(CreateParticipantDto participantDto);
        ParticipantDto UpdateParticipant(Guid id, UpdateParticipantDto participantDto);
        string DeleteParticipant(Guid id);
        ParticipantDto GetParticipantById(Guid id);
        ParticipantDto GetParticipantByUserId(Guid id);
        List<ParticipantDto> GetAllParticipant();
    }
}
