using AutoMapper;
using BbCenter.Dto.Auth;
using BbCenter.Dto.Booking;
using BbCenter.Dto.Center;
using BbCenter.Dto.ClassRoom;
using BbCenter.Dto.Participant;
using BbCenter.Dto.Schedule;
using BbCenter.Dto.Subject;
using BbCenter.Dto.User;
using BbCenter.Models;

namespace BbCenter.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<CreateCenterDto, Center>();
            CreateMap<UpdateCenterDto, Center>();
            CreateMap<Center, CenterDto>();

            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<UpdateSubjectDto, Subject>();
            CreateMap<Subject, SubjectDto>();

            CreateMap<CreateBookingDto, Booking>();
            CreateMap<UpdateBookingDto, Booking>();
            CreateMap<Booking, BookingDto>();

            CreateMap<CreateClassRoomDto, ClassRoom>();
            CreateMap<UpdateClassRoomDto, ClassRoom>();
            CreateMap<ClassRoom, ClassRoomDto>();

            CreateMap<CreateParticipantDto, Participant>();
            CreateMap<UpdateParticipantDto, Participant>();
            CreateMap<Participant, ParticipantDto>();

            CreateMap<CreateScheduleDto, Schedule>();
            CreateMap<UpdateScheduleDto, Schedule>();
            CreateMap<Schedule, ScheduleDto>();

        }
    }
}
