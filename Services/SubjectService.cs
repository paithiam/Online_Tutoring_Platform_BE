using AutoMapper;
using BbCenter.Dto.Subject;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Services.Interface;
using BbSubject.Repositories.Interface;

namespace BbCenter.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepositories _subjectRepository;
        private readonly IScheduleService _scheduleService;
        private readonly IBookingService _bookingService;

        public SubjectService(IMapper mapper, ISubjectRepositories subjectRepository, IScheduleService scheduleService, IBookingService bookingService)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _scheduleService = scheduleService;
            _bookingService = bookingService;
        }

        public SubjectDto AddSubject(CreateSubjectDto subjectDto)
        {
            Subject subject = _subjectRepository.GetSubjectName(subjectDto.SubjectName);

            if (subject != null)
            {
                throw new ConflictException("The subject name already exists");
            }

            subject = _mapper.Map<Subject>(subjectDto);
            _subjectRepository.CreateSubject(subject);

            return _mapper.Map<SubjectDto>(subject);
        }

        public string DeleteSubject(Guid id)
        {
            Subject subject = _subjectRepository.GetSubjectById(id) ?? throw new NotFoundException("The subject does not exists");

            if (subject.Schedules.Count > 0)
            {
                foreach (Schedule schedule in subject.Schedules)
                {
                    _scheduleService.DeleteSchedule(schedule.ScheduleId);
                }
            }

            if (subject.Bookings.Count > 0)
            {
                foreach (Booking booking in subject.Bookings)
                {
                    _bookingService.DeleteBooking(booking.BookingId);

                }
            }

            _subjectRepository.DeleteSubject(subject);
            return "Delete successful";
        }

        public List<SubjectDto> GetAllSubject()
        {
            List<Subject> SubjectList = _subjectRepository.GetAllSubject();
            return _mapper.Map<List<SubjectDto>>(SubjectList);
        }

        public SubjectDto GetSubjectById(Guid id)
        {
            Subject subject = _subjectRepository.GetSubjectById(id) ?? throw new NotFoundException("The subject does not exists");

            return _mapper.Map<SubjectDto>(subject);
        }

        public SubjectDto UpdateSubject(Guid id, UpdateSubjectDto SubjectDto)
        {
            _ = _subjectRepository.GetSubjectById(id) ?? throw new NotFoundException("Subject does not exists");


            SubjectDto.SubjectId = id;

            Subject subjectUpdate = _mapper.Map<Subject>(SubjectDto);
            _subjectRepository.UpdateSubject(subjectUpdate);

            return _mapper.Map<SubjectDto>(subjectUpdate);
        }
    }
}
