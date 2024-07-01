using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private ISessionRepository _repository;
        public SessionController(ISessionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetSessionByTeacher/{teacherId}")]
        public IActionResult GetSessionByTeacherId(int teacherId) {
            try
            {
                var result = _repository.GetSessionsByTeacherId(teacherId);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetSessionByStudent/{studentId}")]
        public IActionResult GetSessionByStudentId(int studentId)
        {
            try
            {
                var result = _repository.GetSessionsByStudentId(studentId);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
