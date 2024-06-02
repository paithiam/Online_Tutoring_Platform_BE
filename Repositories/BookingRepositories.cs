using BbCenter.Constraints;
using BbCenter.Dto.Booking;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace BbCenter.Repositories
{
    public class BookingRepositories : IBookingRepositories
    {
        private readonly ApplicationDbContext _context;

        public BookingRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBooking(Booking booking)
        {
            try
            {

                _context.Bookings.Add(booking);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating Booking");
            }
        }

        public void UpdateBooking(Guid teacherId, string classId, Booking booking, int? slot, DateTime bookingDate)
        {
            try
            {
                if (classId != "empty")
                {

                    List<Schedule> conflicts = (from schedule in _context.Schedules
                                                join participant in _context.Participants on schedule.ParticipantId equals participant.ParticipantId
                                                join classRoom in _context.ClassRooms on participant.ClassId equals classRoom.ClassId
                                                where schedule.ScheduleDate.Date == bookingDate.Date && schedule.Slot == slot
                                                select schedule).ToList();

                    if (conflicts.Count != 0)
                    {
                        throw new Exception("The booking conflicts with an existing class schedule.");
                    }

                    Participant participantToAdd = new Participant();
                    participantToAdd.UserId = teacherId;
                    Guid guid = Guid.Parse(classId);
                    participantToAdd.ClassId = guid;
                    _context.Participants.Add(participantToAdd);

                    Schedule scheduleToAdd = new Schedule();
                    scheduleToAdd.ParticipantId = participantToAdd.ParticipantId;
                    scheduleToAdd.SubjectId = booking.SubjectId;
                    scheduleToAdd.Slot = booking.Slot;
                    scheduleToAdd.ScheduleDate = bookingDate;

                    _context.Schedules.Add(scheduleToAdd);
                }

                _context.Entry<Booking>(booking).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting Booking");
            }
        }

        public List<Booking> GetAllBooking()
        {
            try
            {
                return _context.Bookings.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Error fetch Booking");
            }
        }

        public List<Booking> GetBookingByCenterIdOrStudentIdOrTeacherId(QueryDto queryDto)
        {
            try
            {
                var query = _context.Bookings
                    .Include(a => a.Student)
                    .Include(a => a.Teacher)
                    .Include(a => a.Subject)
                    .Include(a => a.Center)
                    .AsQueryable();

                List<Booking> bookings = query.ToList();

                if (queryDto.CenterId.HasValue)
                {
                    query = query.Where(u => u.CenterId == queryDto.CenterId);
                }
                if (queryDto.TeacherId.HasValue)
                {
                    query = query.Where(u => u.TeacherId == queryDto.TeacherId);

                }
                if (queryDto.StudentId.HasValue)
                {
                    query = query.Where(u => u.StudentId == queryDto.StudentId);

                }
                if (queryDto.BType.HasValue)
                {
                    if (queryDto.BType.Value.Equals(EBookingType.Tutor))
                    {
                        query = query.Where(u => u.BType == EBookingType.Tutor);
                    }
                    if (queryDto.BType.Value.Equals(EBookingType.Center))
                    {
                        query = query.Where(u => u.BType == EBookingType.Center);
                    }
                    else
                    {
                        query = query.Where(u => u.BType == EBookingType.Online);
                    }

                }
                if (queryDto.BStatus.HasValue)
                {
                    if (queryDto.BStatus.Value.Equals(EBookingStatus.Pending))
                    {
                        query = query.Where(u => u.BStatus == EBookingStatus.Pending);
                    }
                    if (queryDto.BStatus.Value.Equals(EBookingStatus.Confirmed))
                    {
                        query = query.Where(u => u.BStatus == EBookingStatus.Confirmed);
                    }
                    else
                    {
                        query = query.Where(u => u.BStatus == EBookingStatus.Reject);
                    }

                }

                bookings = query.ToList();

                return bookings;
            }
            catch (Exception)
            {
                throw new Exception("Error getting Booking");
            }
        }

        public Booking GetBookingByDate(DateTime bookingDate)
        {
            try
            {
                Booking booking = _context.Bookings.FirstOrDefault(u => u.BookingDate == bookingDate);
                return booking;
            }
            catch (Exception)
            {
                throw new Exception("Error getting booking");
            }
        }

        public Booking GetBookingById(Guid id)
        {
            try
            {
                return _context.Bookings
                    .Include(b => b.Student)
                    .Include(b => b.Teacher)
                    .Include(b => b.Subject)
                    .Include(b => b.Center).AsNoTracking()
                    .FirstOrDefault(b => b.BookingId == id);
            }
            catch (Exception)
            {
                throw new Exception("Error getting booking");
            }
        }
    }
}