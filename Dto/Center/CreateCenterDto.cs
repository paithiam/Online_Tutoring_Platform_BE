using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Center
{
    public class CreateCenterDto
    {
        [Required(ErrorMessage = "The Center can not empty!")]
        public string CenterName { get; set; }

        [Required(ErrorMessage = "The Location can not empty!")]
        public string CenterLocation { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The Phone Number can not empty!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Email can not empty!")]
        public string Email { get; set; }

    }
}
