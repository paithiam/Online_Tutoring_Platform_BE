using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Models
{
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ParticipantId { get; set; }
        public Guid UserId { get; set; }
        public Guid ClassId { get; set; }



        [ForeignKey("ClassId")]
        public virtual ClassRoom? ClassRoom { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }


        public virtual ICollection<Schedule>? Schedules { get; set; }

    }
}
