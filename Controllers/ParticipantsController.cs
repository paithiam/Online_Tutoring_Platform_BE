using BbCenter.Dto.Center;
using BbCenter.Dto;
using BbCenter.Exceptions;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using BbCenter.Dto.Participant;

namespace BbCenter.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<ParticipantDto> Participants = _participantService.GetAllParticipant();
            return Ok(Participants);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseDto response = new();
            try
            {
                ParticipantDto ParticipantDto = _participantService.GetParticipantById(id);
                return Ok(ParticipantDto);
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

        [HttpGet("{userId}")]
        public IActionResult GetParticipantByUserId(Guid userId)
        {
            ResponseDto response = new();
            try
            {
                ParticipantDto ParticipantDto = _participantService.GetParticipantByUserId(userId);
                return Ok(ParticipantDto);
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
        public IActionResult Post([FromBody] CreateParticipantDto createParticipantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                ParticipantDto ParticipantDto = _participantService.AddParticipant(createParticipantDto);
                return Ok(ParticipantDto);
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
        public IActionResult Put(Guid id, [FromBody] UpdateParticipantDto updateAMDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                ParticipantDto faculty = _participantService.UpdateParticipant(id, updateAMDto);

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
                response.Message = _participantService.DeleteParticipant(id);

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
