using AutoMapper;
using BbCenter.Dto.Schedule;
using BbCenter.Models;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;

namespace BbCenter.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepositories _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepositories scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public void CreateSchedule(CreateScheduleDto createScheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(createScheduleDto);
            try
            {
                _scheduleRepository.CreateSchedule(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating schedule", ex);
            }
        }

        public void DeleteSchedule(Guid id)
        {
            try
            {
                var schedule = _scheduleRepository.GetScheduleById(id);
                if (schedule == null)
                {
                    throw new Exception("Schedule not found");
                }
                _scheduleRepository.DeleteSchedule(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting schedule", ex);
            }
        }

        public List<ScheduleDto> GetAllSchedules()
        {
            try
            {
                var schedules = _scheduleRepository.GetAllSchedule();
                return _mapper.Map<List<ScheduleDto>>(schedules);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all schedules", ex);
            }
        }

        public ScheduleDto GetScheduleById(Guid id)
        {
            try
            {
                var schedule = _scheduleRepository.GetScheduleById(id);
                return _mapper.Map<ScheduleDto>(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedule by ID", ex);
            }
        }

        public List<ScheduleDto> GetSchedulesByDate(DateTime scheduleDate)
        {
            try
            {
                var schedules = _scheduleRepository.GetScheduleByDate(scheduleDate);
                return _mapper.Map<List<ScheduleDto>>(schedules);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedules by date", ex);
            }
        }

        public List<ScheduleDto> GetSchedulesBySubjectIdOrParticipantId(QueryDto queryDto)
        {
            try
            {
                var schedules = _scheduleRepository.GetScheduleBySubjectIdOrParticipantId(queryDto);
                return _mapper.Map<List<ScheduleDto>>(schedules);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedules by subject or participant", ex);
            }
        }

        public void UpdateSchedule(UpdateScheduleDto updateScheduleDto, Guid id)
        {
            try
            {
                var schedule = _scheduleRepository.GetScheduleById(id);
                if (schedule == null)
                {
                    throw new Exception("Schedule not found");
                }

                _mapper.Map(updateScheduleDto, schedule);
                _scheduleRepository.UpdateSchedule(schedule);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating schedule", ex);
            }
        }
    
    }
}
