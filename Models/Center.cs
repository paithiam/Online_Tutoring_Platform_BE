using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BbCenter.Models
{
    public class Center
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CenterId { get; set; }

        [StringLength(50)]
        public string CenterName { get; set; }

        public string CenterLocation { get; set; }

        public string Description { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<ClassRoom>? ClassRooms { get; set; }
    }
}
