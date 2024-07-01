using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllCourse")]
        public IActionResult GetAllCourse() {
            try
            {
                var result = _repository.GetAllCourses();
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }
    }
}
