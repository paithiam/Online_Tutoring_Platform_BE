using BbCenter.Models;
using BbCenter.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BbCenter.Repositories
{
    public class ClassRoomRepositories  : IClassRoomRepositories
    {
        private readonly ApplicationDbContext _context;

        public ClassRoomRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateClassRoom(ClassRoom classRoom)
        {
            try
            {
                _context.ClassRooms.Add(classRoom);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating ClassRoom");
            }
        }

        public void DeleteClassRoom(ClassRoom classRoom)
        {
            try
            {
                _context.ClassRooms.Remove(classRoom);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting ClassRoom");
            }
        }

        public List<ClassRoom> GetAllClassRoom()
        {
            try
            {
                return _context.ClassRooms.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetch ClassRoom");
            }
        }

        public List<ClassRoom> GetClassRoomByCenterId(Guid id)
        {
            try
            {
                return _context.ClassRooms.Where(u => u.CenterId == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error getting ClassRoom");
            }
        }

        public ClassRoom GetClassRoomById(Guid id)
        {
            try
            {
                return _context.ClassRooms.Where(u => u.ClassId == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting ClassRoom");
            }
        }

        public ClassRoom GetClassRoomName(string name)
        {
            try
            {
                return _context.ClassRooms.Where(u => u.ClassName == name).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting ClassRoom");
            }
        }

        public void UpdateClassRoom(ClassRoom classRoom)
        {
            try
            {
                _context.Entry(classRoom).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating ClassRoom");
            }
        }
    }
}
