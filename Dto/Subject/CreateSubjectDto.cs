using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Subject
{
    public class CreateSubjectDto
    {
        [Required(ErrorMessage = "The Subject can not empty!")]
        public string SubjectName { get; set; }

        public string SubjectDescription { get; set; }

    }
}
