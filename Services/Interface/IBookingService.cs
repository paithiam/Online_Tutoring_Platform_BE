using BbCenter.Dto.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BbCenter.Services.Interface
{
    public interface IBookingService
    {
        BookingDto AddBooking(CreateBookingDto bookingDto);
        BookingDto UpdateBooking(Guid id, UpdateBookingDto bookingDto);
        string DeleteBooking(Guid id);
        BookingDto GetBookingById(Guid id);
        List<BookingDto> GetAllBooking();
       List< BookingDto> GetBookingByUserId(QueryDto queryDto);
        List<BookingDto> GetBookingByDate(DateTime bookingDate);    

        /*        List<BookingDto> GetBookingBySubjectId(Guid subjecId);*/
        /*        List<BookingDto> GetBookingByTypeOrStatus(QueryDto queryDto);*/
        List<BookingDto> GetBookingByCenterIdOrStudentIdOrTeacherId(QueryDto queryDto);
    }
}
