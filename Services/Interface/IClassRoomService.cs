using BbCenter.Dto.ClassRoom;

namespace BbCenter.Services.Interface
{
    public interface IClassRoomService
    {
        ClassRoomDto AddClassRoom(CreateClassRoomDto classRoomDto);
        ClassRoomDto UpdateClassRoom(Guid id, UpdateClassRoomDto classRoomDto);
        string DeleteClassRoom(Guid id);
        ClassRoomDto GetClassRoomById(Guid id);
        List<ClassRoomDto> GetClassRoomByCenterId(Guid id);
        List<ClassRoomDto> GetAllClassRoom();
    }
}
