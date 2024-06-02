using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Subject
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string SubjectDescription { get; set; }

    }
}
