using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IParticipantRepositories
    {
        void CreateParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void DeleteParticipant(Participant participant);
        Participant GetparticipantById(Guid id);
        Participant GetparticipantByUserId(Guid id);
        List<Participant> GetAllparticipant();
    }
}
