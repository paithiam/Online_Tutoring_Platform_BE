using System.ComponentModel.DataAnnotations;

namespace BbCenter.Dto.Center
{
    public class CenterDto
    {
        public Guid CenterId { get; set; }

        public string CenterName { get; set; }

        public string CenterLocation { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


    }
}
