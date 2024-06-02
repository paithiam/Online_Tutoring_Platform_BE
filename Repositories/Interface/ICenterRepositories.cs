using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface ICenterRepositories
    {
        void CreateCenter(Center center);
        Center GetCenterName(string name);
        Center GetCenterById(Guid id);
        List<Center> GetAllCenter();

        void UpdateCenter(Center center);
        void DeleteCenter(Center center);
    }
}
