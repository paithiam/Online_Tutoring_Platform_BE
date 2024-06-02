using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BbCenter.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid SubjectId { get; set; }
        public int Slot { get; set; }

        [ForeignKey("ParticipantId")]
        public virtual Participant? Participant { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }
    }
}
