using BbCenter.Dto.Schedule;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BbCenter.Repositories
{
    public class ScheduleRepositories : IScheduleRepositories
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating schedule", ex);
            }
        }

        public void DeleteSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting schedule", ex);
            }
        }

        public List<Schedule> GetAllSchedule()
        {
            try
            {
                return _context.Schedules
                               .Include(s => s.Participant)
                               .Include(s => s.Subject)
                               .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all schedules", ex);
            }
        }

        public Schedule GetScheduleByDate(DateTime scheduleDate)
        {
            try
            {
                return _context.Schedules
                               .Include(s => s.Participant)
                               .Include(s => s.Subject)
                               .FirstOrDefault(s => s.ScheduleDate.Date == scheduleDate.Date);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedule by date", ex);
            }
        }

        public Schedule GetScheduleById(Guid id)
        {
            try
            {
                return _context.Schedules
                               .Include(s => s.Participant)
                               .Include(s => s.Subject)
                               .FirstOrDefault(s => s.ScheduleId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedule by ID", ex);
            }
        }

        public List<Schedule> GetScheduleBySubjectIdOrParticipantId(QueryDto queryDto)
        {
            try
            {
                var query = _context.Schedules.AsQueryable();

                if (queryDto.SubjectId.HasValue)
                {
                    query = query.Where(s => s.SubjectId == queryDto.SubjectId.Value);
                }

                if (queryDto.ParticipantId.HasValue)
                {
                    query = query.Where(s => s.ParticipantId == queryDto.ParticipantId.Value);
                }

                return query
                        .Include(s => s.Participant)
                        .Include(s => s.Subject)
                        .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedules by subject or participant", ex);
            }
        
        }

        public void UpdateSchedule(Schedule schedule)
        {
            try
            {
                _context.Schedules.Update(schedule);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating schedule", ex);
            }
        }
    }
}
