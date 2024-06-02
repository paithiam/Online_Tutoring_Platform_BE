using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IClassRoomRepositories
    {
        void CreateClassRoom(ClassRoom classRoom);
        ClassRoom GetClassRoomName(string name);
        ClassRoom GetClassRoomById(Guid id);
        List<ClassRoom> GetAllClassRoom();
        List<ClassRoom> GetClassRoomByCenterId(Guid id);

        void UpdateClassRoom(ClassRoom classRoom);
        void DeleteClassRoom(ClassRoom classRoom);
    }
}
