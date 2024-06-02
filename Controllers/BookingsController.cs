using BbCenter.Dto;
using BbCenter.Dto.Booking;
using BbCenter.Exceptions;
using BbCenter.Models;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BbCenter.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<BookingDto> bookings = _bookingService.GetAllBooking();
            return Ok(bookings);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseDto response = new();
            try
            {
                BookingDto bookingDto = _bookingService.GetBookingById(id);
                return Ok(bookingDto);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("user")]
        public IActionResult GetContrubutionByUserId([FromQuery] QueryDto queryDto)
        {
            ResponseDto response = new();
            try
            {
                List<BookingDto> bookings = _bookingService.GetBookingByCenterIdOrStudentIdOrTeacherId(queryDto);
                return Ok(bookings);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("booking/{BookingDate}")]
        public IActionResult GetBookingByBookingDate(DateTime bookingDate)
        {
            ResponseDto response = new();
            try
            {
                List<BookingDto> bookings = _bookingService.GetBookingByDate(bookingDate);
                return Ok(bookings);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                int slot = Int32.Parse(createBookingDto.Slot.ToString());
                createBookingDto.Slot = slot;
                BookingDto bookingDto = _bookingService.AddBooking(createBookingDto);
                return Ok(bookingDto);
            }
            catch (ConflictException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                BookingDto booking = _bookingService.UpdateBooking(id, updateBookingDto);
                return Ok(booking);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            ResponseDto response = new();
            try
            {
                response.Message = _bookingService.DeleteBooking(id);

                return Ok(response);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

    }
}
