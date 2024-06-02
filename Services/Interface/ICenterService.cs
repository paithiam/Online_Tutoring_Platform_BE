using BbCenter.Dto.Center;


namespace BbCenter.Services.Interface
{
    public interface ICenterService
    {
        CenterDto AddCenter(CreateCenterDto CenterDto);
        CenterDto UpdateCenter(Guid id, UpdateCenterDto CenterDto);
        string DeleteCenter(Guid id);
        CenterDto GetCenterById(Guid id);
        List<CenterDto> GetAllCenter();
    }
}
    