using BbCenter.Dto.Subject;
using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Subject
{
    public class UpdateSubjectDto : CreateSubjectDto
   
    {
        public Guid SubjectId { get; set; }
    }
}
