using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SubjectId { get; set; }

        [StringLength(50)]
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        

        public virtual ICollection<Schedule>? Schedules { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
