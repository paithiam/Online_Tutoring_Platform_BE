using BbCenter.Models;

namespace BbSubject.Repositories.Interface
{
    public interface ISubjectRepositories
    {
        void CreateSubject(Subject Subject);
        Subject GetSubjectName(string name);
        Subject GetSubjectById(Guid id);
        List<Subject> GetAllSubject();

        void UpdateSubject(Subject Subject);
        void DeleteSubject(Subject Subject);
    }
}
