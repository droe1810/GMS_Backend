using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionStudentController : ControllerBase
    {
        private ISessionStudentRepository _repository;
        public SessionStudentController(ISessionStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAvgGrade/{courseId}/{studentId}")]
        public IActionResult GetAvgGrade(int courseId, int studentId) {
            try
            {
                var result = _repository.GetAvgGrade(courseId, studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetStatus/{courseId}/{studentId}")]
        public IActionResult GetStatus(int courseId, int studentId)
        {
            try
            {
                var result = _repository.GetStatus(courseId, studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
