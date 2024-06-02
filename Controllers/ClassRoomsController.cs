using BbCenter.Dto.Center;
using BbCenter.Dto;
using BbCenter.Exceptions;
using BbCenter.Services;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using BbCenter.Dto.ClassRoom;

namespace BbCenter.Controllers
{
    [Route("api/classRooms")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomsController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClassRoomDto> ClassRooms = _classRoomService.GetAllClassRoom();
            return Ok(ClassRooms);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseDto response = new();
            try
            {
                ClassRoomDto ClassRoomDto = _classRoomService.GetClassRoomById(id);
                return Ok(ClassRoomDto);
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

        [HttpGet("center/{id}")]
        public IActionResult GetClassRoomByCenterId(Guid id)
        {
            ResponseDto response = new();
            try
            {
                List<ClassRoomDto> ClassRoomDto = _classRoomService.GetClassRoomByCenterId(id);
                return Ok(ClassRoomDto);
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
        public IActionResult Post([FromBody] CreateClassRoomDto createClassRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                ClassRoomDto ClassRoomDto = _classRoomService.AddClassRoom(createClassRoomDto);
                return Ok(ClassRoomDto);
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
        public IActionResult Put(Guid id, [FromBody] UpdateClassRoomDto updateAMDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                ClassRoomDto faculty = _classRoomService.UpdateClassRoom(id, updateAMDto);

                return Ok(faculty);
            }
            catch (NotFoundException e)
            {
                response.Message = e.Message;
                return StatusCode(StatusCodes.Status404NotFound, response);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            ResponseDto response = new();
            try
            {
                response.Message = _classRoomService.DeleteClassRoom(id);

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
