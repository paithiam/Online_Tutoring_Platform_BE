using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using BbCenter.Constraints;

namespace BbCenter.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookingId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid CenterId { get; set; }
        public int Slot { get; set; }
        public DateTime BookingDate { get; set; }
        public virtual User? Student { get; set; }
        public virtual User? Teacher { get; set; }          

        public EBookingType BType { get; set; }
        public EBookingStatus BStatus { get; set; }

        [ForeignKey("CenterId")]
        public virtual Center? Center { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }
    }
}
