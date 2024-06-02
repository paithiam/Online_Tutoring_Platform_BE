using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Schedule
{
    public class ScheduleDto
    {
        public Guid ScheduleId { get; set; }

        public DateTime ScheduleDate { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SlotId { get; set; }
      
    }
}