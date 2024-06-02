using BbCenter.Constraints;
using BbCenter.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BbCenter.Dto.Center;

namespace BbCenter.Dto.ClassRoom
{
    public class ClassRoomDto
    {
        public Guid ClassId { get; set; }
        public Guid CenterId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public CenterDto? Center { get; set; }

    }
}
