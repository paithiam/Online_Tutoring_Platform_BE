using BbCenter.Dto;
using BbCenter.Dto.Center;
using BbCenter.Exceptions;
using BbCenter.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BbCenter.Controllers
{
    [Route("api/centers")]
    [ApiController]
    public class CentersController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public CentersController(ICenterService centerService)
        {
            _centerService = centerService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<CenterDto> Centers = _centerService.GetAllCenter();
            return Ok(Centers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseDto response = new();
            try
            {
                CenterDto CenterDto = _centerService.GetCenterById(id);
                return Ok(CenterDto);
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
        public IActionResult Post([FromBody] CreateCenterDto createCenterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                CenterDto CenterDto = _centerService.AddCenter(createCenterDto);
                return Ok(CenterDto);
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
        public IActionResult Put(Guid id, [FromBody] UpdateCenterDto updateAMDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDto response = new();
            try
            {
                CenterDto faculty = _centerService.UpdateCenter(id, updateAMDto);

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
                response.Message = _centerService.DeleteCenter(id);

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
