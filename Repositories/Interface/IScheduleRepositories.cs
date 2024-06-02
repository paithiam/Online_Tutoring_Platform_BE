using BbCenter.Dto.Schedule;
using BbCenter.Models;

namespace BbCenter.Repositories.Interface
{
    public interface IScheduleRepositories
    {
        void CreateSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
        Schedule GetScheduleByDate(DateTime scheduleDate);
        Schedule GetScheduleById(Guid id);
        List<Schedule> GetAllSchedule();
        List<Schedule> GetScheduleBySubjectIdOrParticipantId(QueryDto queryDto);
    }
}
