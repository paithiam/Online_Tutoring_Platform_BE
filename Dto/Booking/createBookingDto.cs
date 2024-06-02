using BbCenter.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Booking
{
    public class CreateBookingDto
    {

        [Required(ErrorMessage = "The Booking Date can not empty!")]
        public DateTime BookingDate { get; set; }

        public Guid? StudentId { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? CenterId { get; set; }
        public int? Slot { get; set; }
        public string? ClassId { get; set; }

        [Required(ErrorMessage = "The learning type can not empty!")]
        public string BType { get; set; }
        public string BStatus { get; set; }

        public UserDto? Student { get; set; }
        public UserDto? Teacher { get; set; }
    }
}
