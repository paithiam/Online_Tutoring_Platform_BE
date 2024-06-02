using Microsoft.EntityFrameworkCore;
using BbCenter.Models;
using BbSubject.Repositories.Interface;


namespace BbCenter.Repositories
{
    public class SubjectRepositories : ISubjectRepositories
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateSubject(Subject subject)
        {
            try
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating Subject");
            }
        }

        public void DeleteSubject(Subject subject)
        {
            try
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting Subject");
            }
        }

        public List<Subject> GetAllSubject()
        {
            try
            {
                return _context.Subjects.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetch Subject");
            }
        }

        public Subject GetSubjectById(Guid id)
        {
            try
            {
                return _context.Subjects
                    .Include(u => u.Schedules)
                    .Include(u => u.Bookings)
                    .Where(u => u.SubjectId == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting Subject");
            }
        }

        public Subject GetSubjectName(string name)
        {
            try
            {
                return _context.Subjects.Where(u => u.SubjectName == name).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting Subject Name");
            }
        }

        public void UpdateSubject(Subject subject)
        {
            try
            {
                _context.Entry(subject).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating Subject");
            }
        }
    }
}
