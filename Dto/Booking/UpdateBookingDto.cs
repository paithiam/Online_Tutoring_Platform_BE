namespace BbCenter.Dto.Booking
{
    public class UpdateBookingDto : CreateBookingDto
    {
        public Guid BookingId { get; set; }
    }
}
