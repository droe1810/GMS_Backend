using BussinessObject.DTO.Request;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private IRequestRepository _repository;
        public RequestController(IRequestRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateRequest/{studentId}/{gradeId}/{requestContent}")]
        public IActionResult CreateRequest(int studentId, int gradeId, string requestContent) {
            try
            {
                var result = _repository.CreateRequest(studentId, gradeId, requestContent);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllRequest")]
        public IActionResult GetAllRequest() {
            try
            {
                var result = _repository.GetAllRequest();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetRequest/{studentId}")]
        public IActionResult GetRequest(int studentId)
        {
            try
            {
                var result = _repository.GetRequest(studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("UpdateRequest")]
        public IActionResult UpdateRequest([FromBody] UpdateRequestDTO rDTO) {
            try
            {
                var result = _repository.UpdateRequest(rDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
               
            }
        }
    }
}
