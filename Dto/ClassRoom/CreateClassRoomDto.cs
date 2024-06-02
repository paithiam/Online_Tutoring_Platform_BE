using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.ClassRoom
{
    public class CreateClassRoomDto
    {
        [Required(ErrorMessage = "The Name can not empty!")]
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public Guid CenterId { get; set; }
        
    }
}
