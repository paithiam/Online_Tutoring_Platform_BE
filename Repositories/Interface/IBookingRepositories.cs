using BbCenter.Constraints;
using BbCenter.Dto.Booking;
using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IBookingRepositories
    {
        void CreateBooking(Booking booking);
        void UpdateBooking(Guid teacherId, string classId, Booking booking, int? slot, DateTime bookingDate);
        void DeleteBooking(Booking Booking);
        Booking GetBookingByDate(DateTime bookingDate);
        Booking GetBookingById(Guid id);
        List<Booking> GetAllBooking();
        List<Booking> GetBookingByCenterIdOrStudentIdOrTeacherId(QueryDto queryDto);
    }
}
