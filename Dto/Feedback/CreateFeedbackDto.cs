using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Feedback
{
	public class CreateFeedbackDto
	{
		[Required(ErrorMessage = "The Content can not empty!")]
		public string Content { get; set; }

		[Required(ErrorMessage = "The date can not empty!")]
		public DateTime FeedbackDate { get; set; }

		public Guid UserId { get; set; }

		public Guid SubjectId { get; set; }
	}
}
