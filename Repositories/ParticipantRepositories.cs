using BbCenter.Models;
using BbCenter.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BbCenter.Repositories
{
    public class ParticipantRepositories : IParticipantRepositories
    {
        private readonly ApplicationDbContext _context;

        public ParticipantRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateParticipant(Participant participant)
        {
            try
            {
                _context.Participants.Add(participant);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating Participant");
            }
        }
        public void UpdateParticipant(Participant participant)
        {
            try
            {
                _context.Entry(participant).State = EntityState.Detached;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating Participant");
            }
        }

        public void DeleteParticipant(Participant participant)
        {
            try
            {
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting Participant");
            }
        }


        public Participant GetparticipantById(Guid id)
        {
            return _context.Participants
                       .Include(b => b.User)
                       .Include(b => b.ClassRoom)
                       .FirstOrDefault(b => b.ParticipantId == id);
        }

        public List<Participant> GetAllparticipant()
        {
            try
            {
                return _context.Participants.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetch Participant");
            }
        }

        public Participant GetparticipantByUserId(Guid id)
        {
            return _context.Participants
                       .Include(b => b.User)
                       .Include(b => b.ClassRoom)
                       .FirstOrDefault(b => b.UserId == id);
        }
    }
}
