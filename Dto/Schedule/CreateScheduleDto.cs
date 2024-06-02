using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Schedule
{
    public class CreateScheduleDto
    {

        [Required(ErrorMessage = "The Schedule Date  can not empty!")]
        public DateTime ScheduleDate { get; set; }

        [Required(ErrorMessage = "The ParticipantId can not empty!")]
        public Guid ParticipantId { get; set; }

        [Required(ErrorMessage = "The SubjectId can not empty!")]
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "The SlotId can not empty!")]
        public Guid SlotId { get; set; }
    }
}
