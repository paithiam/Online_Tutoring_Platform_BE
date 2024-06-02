using BbCenter.Constraints;

namespace BbCenter.Dto.Schedule
{
	public class QueryDto
	{
		public Guid? ScheduleId { get; set; }
		public Guid? SubjectId { get; set; }
		public Guid? SlotId { get; set; }
		public Guid? ParticipantId { get; set; }
	}
}