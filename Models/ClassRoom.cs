using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BbCenter.Constraints;

namespace BbCenter.Models
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClassId { get; set; }
        public Guid CenterId { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }
        
        public string ClassDescription { get; set; }

        public virtual ICollection<Participant>? Participants { get; set; }
    }
}
