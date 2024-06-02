using BbCenter.Models;
using BbCenter.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BbCenter.Repositories
{
    public class CenterRepositories : ICenterRepositories
    {
        private readonly ApplicationDbContext _context;

        public CenterRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCenter(Center center)
        {
            try
            {
                _context.Centers.Add(center);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating Center");
            }
        }

        public void DeleteCenter(Center center)
        {
            try
            {
                _context.Centers.Remove(center);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting Center");
            }
        }

        public List<Center> GetAllCenter()
        {
            try
            {
                return _context.Centers.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetch Center");
            }
        }

        public Center GetCenterById(Guid id)
        {
            try
            {
                return _context.Centers.Where(u => u.CenterId == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting Center");
            }
        }

        public Center GetCenterName(string name)
        {
            try
            {
                return _context.Centers.Where(u => u.CenterName == name).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting Center Name");
            }
        }

        public void UpdateCenter(Center center)
        {
            try
            {
                _context.Entry(center).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating Center");
            }
        }
    }
}
