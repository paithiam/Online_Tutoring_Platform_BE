using BbCenter.Constraints;

namespace BbCenter.Dto.Booking
{
	public class QueryDto
	{
        public Guid? BookingId { get; set; }
        public Guid? SubjectId { get; set; }
		public Guid? CenterId { get; set; }
		public Guid? TeacherId { get; set; }	
		public Guid? StudentId { get; set; }
		public EBookingStatus? BStatus { get; set; }
		public EBookingType? BType { get; set; }
	}
}
