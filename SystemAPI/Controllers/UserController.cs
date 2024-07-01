using AutoMapper;
using DataAccess.DataAccess;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        //[HttpGet("GetAlluser")]
        //public IActionResult GetALlUser() {
        //    try
        //    {
        //        var result = _repository.GetAllUsers();
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpGet("GetUser/{username}/{password}")]
        public IActionResult GetUser(string username, string password)
        {
            try
            {
                var result = _repository.GetUser(username, password);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetStudent/{username}")]
        public IActionResult GetStudent(string username)
        {
            try
            {
                var result = _repository.GetStudent(username);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetStudentInSession/{sessionId}")]
        public IActionResult GetStudentInSession(int sessionId)
        {
            try
            {
                var result = _repository.GetStudentInSession(sessionId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("GetStudentByGradeId/{gradeId}")]
        //public IActionResult GetStudentByGradeId(int gradeId)
        //{
        //    try
        //    {
        //        var result = _repository.GetStudentByGradeId(gradeId);
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpGet("GetStudentByCourseId/{courseId}")]
        public IActionResult GetStudentByCourseId(int courseId)
        {
            try
            {
                var result = _repository.GetStudentByCourseId(courseId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("Recharge/{studentId}/{value}")]
        public IActionResult Recharge(int studentId, int value) {
            try
            {
                var result = _repository.Recharge(studentId, value);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("Refund/{studentId}")]
        public IActionResult Refund(int studentId)
        {
            try
            {
                var result = _repository.Refund(studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("DeductFunds/{studentId}")]
        public IActionResult DeductFunds(int studentId)
        {
            try
            {
                var result = _repository.DeductFunds(studentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
