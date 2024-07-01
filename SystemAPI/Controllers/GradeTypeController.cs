using AutoMapper;
using BussinessObject.DTO.GradeType;
using BussinessObject.Models;
using DataAccess.DataAccess;
using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeTypeController : ControllerBase
    {
        private IGradeTypeRepository _repository;
        private IPassConditionRepository _passconditionRepository;
        public GradeTypeController(IGradeTypeRepository repository, IPassConditionRepository passconditionRepository)
        {
            _repository = repository;
            _passconditionRepository = passconditionRepository;
        }


        [HttpGet("GetAllGradeType")]
        public IActionResult GetAllGradeType() {
            try
            {
                var result = _repository.GetAllGradeType();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateGradeType")]
        public IActionResult CreateGradeType(CreateGradeTypeDTO gtDTO) {
            try
            {
                gtDTO.PassConditionId = _passconditionRepository.GetPassConditionId((int)gtDTO.ComparasionTypeId, (int)gtDTO.GradeValue);
                var result = _repository.CreateGradeType(gtDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
