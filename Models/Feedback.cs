using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FeedBackId { get; set; }

        public string Content { get; set; }

        public DateTime FeedbackDate { get; set; }

        public Guid UserId { get; set; }

        public bool IsPublished { get; set; } = false;


        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
