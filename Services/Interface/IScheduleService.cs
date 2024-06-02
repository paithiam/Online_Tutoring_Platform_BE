using BbCenter.Dto.Schedule;

namespace BbCenter.Services.Interface
{
    public interface IScheduleService
    {
        void CreateSchedule(CreateScheduleDto createScheduleDto);
        void UpdateSchedule(UpdateScheduleDto updateScheduleDto, Guid id);
        void DeleteSchedule(Guid id);
        ScheduleDto GetScheduleById(Guid id);
        List<ScheduleDto> GetAllSchedules();
        List<ScheduleDto> GetSchedulesByDate(DateTime scheduleDate);
        List<ScheduleDto> GetSchedulesBySubjectIdOrParticipantId(QueryDto queryDto);
    }
}
