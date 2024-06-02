using AutoMapper;
using BbCenter.Dto.Booking;
using BbCenter.Dto.Center;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Repositories;
using BbCenter.Repositories.Interface;
using BbCenter.Services.Interface;
using BbSubject.Repositories.Interface;

namespace BbCenter.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly ICenterRepositories _centerRepositories;
        private readonly ISubjectRepositories _subjectRepositories;
        private readonly IBookingRepositories _bookingRepositories;

        public BookingService(IMapper mapper, ICenterRepositories centerRepositories, ISubjectRepositories subjectRepositories, IBookingRepositories bookingRepositories)
        {
            _mapper = mapper;
            _centerRepositories = centerRepositories;
            _subjectRepositories = subjectRepositories;
            _bookingRepositories = bookingRepositories;
        }

        public BookingDto AddBooking(CreateBookingDto bookingDto)
        {
           Booking booking = _mapper.Map<Booking>(bookingDto);

            _bookingRepositories.CreateBooking(booking);

            return _mapper.Map<BookingDto>(booking);
        }

        public string DeleteBooking(Guid id)
        {
            Booking booking = _bookingRepositories.GetBookingById(id) ?? throw new NotFoundException("Booking does not exists");
            _bookingRepositories.DeleteBooking(booking);

            return "Delete successful"; ;
        }

        public List<BookingDto> GetAllBooking()
        {
            List<Booking> bookingList = _bookingRepositories.GetAllBooking();
            return _mapper.Map<List<BookingDto>>(bookingList);
        }

        public List<BookingDto> GetBookingByDate(DateTime bookingDate)
        {
            Booking bookings = _bookingRepositories.GetBookingByDate(bookingDate);
            return _mapper.Map<List<BookingDto>>(bookings);
        }
        public BookingDto GetBookingById(Guid id)
        {
            Booking booking = _bookingRepositories.GetBookingById(id) ?? throw new NotFoundException("Booking does not exists");
            return _mapper.Map<BookingDto>(booking);
        }


        public BookingDto UpdateBooking(Guid id, UpdateBookingDto bookingDto)
        {
            _ = _bookingRepositories.GetBookingById(id) ?? throw new NotFoundException("Booking does not exists");

            bookingDto.BookingId = id;

            Booking BookingToUpdate = _mapper.Map<Booking>(bookingDto);
            _bookingRepositories.UpdateBooking(BookingToUpdate.TeacherId, bookingDto.ClassId, BookingToUpdate, BookingToUpdate.Slot, BookingToUpdate.BookingDate);

            return _mapper.Map<BookingDto>(BookingToUpdate);
        }

        public List<BookingDto> GetBookingByUserId(QueryDto queryDto)
        {
            List<Booking> bookingList = _bookingRepositories.GetBookingByCenterIdOrStudentIdOrTeacherId(queryDto);
            return _mapper.Map<List<BookingDto>>(bookingList);
        }

        public List<BookingDto> GetBookingByCenterIdOrStudentIdOrTeacherId(QueryDto queryDto)
        {
            List<Booking> bookingList = _bookingRepositories.GetBookingByCenterIdOrStudentIdOrTeacherId(queryDto);
            return _mapper.Map<List<BookingDto>>(bookingList);
        }
    } 
}