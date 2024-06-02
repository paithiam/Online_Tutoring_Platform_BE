using BbCenter.Constraints;
using BbCenter.Dto.Center;
using BbCenter.Dto.Subject;
using BbCenter.Dto.User;
using BbCenter.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BbCenter.Dto.Booking
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? CenterId { get; set; }
        public int? Slot { get; set; }
        public Guid? ClassId { get; set; }
        public DateTime BookingDate { get; set; }
        public  UserDto? Student { get; set; }
        public  UserDto? Teacher { get; set; }
        public  SubjectDto? Subject { get; set; }
        public CenterDto? Center { get; set; }
        public string BType { get; set; }
        public string BStatus { get; set; }
    }
}
