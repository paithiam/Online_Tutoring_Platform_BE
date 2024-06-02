using BbCenter.Dto.Subject;


namespace BbCenter.Services.Interface
{
    public interface ISubjectService
    {
        SubjectDto AddSubject(CreateSubjectDto SubjectDto);
        SubjectDto UpdateSubject(Guid id, UpdateSubjectDto SubjectDto);
        string DeleteSubject(Guid id);
        SubjectDto GetSubjectById(Guid id);
        List<SubjectDto> GetAllSubject();
    }
}
