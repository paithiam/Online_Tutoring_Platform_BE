using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Participant
{
    public class CreateParticipantDto
    {
        [Required(ErrorMessage = "The UserId can not empty!")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "The ClassRoom Id can not empty!")]
        public Guid ClassId { get; set; }
    }
}
