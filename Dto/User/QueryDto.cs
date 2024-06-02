namespace BbCenter.Dto.User
{
    public class QueryDto
    {
        public Guid? RoleId { get; set; }
        public Guid? CenterId { get; set; }
        public Guid? SubjectId { get; set; }
        public string? Email { get; set; }
    }
}
