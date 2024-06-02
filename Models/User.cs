using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BbCenter.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public string Password { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }

        public string? Degree { get; set; }
        public Guid RoleId { get; set; }
        public Guid? CenterId { get; set; }
        public Guid? SubjectId { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role? Role { get; set; }
        [ForeignKey("CenterId")]
        public virtual Center? Center { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }

        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Booking>? TeacherSelected { get; set; }
        public virtual ICollection<Booking>? StudentSeleced { get; set; }
    }
}
