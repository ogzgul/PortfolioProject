using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        IExperienceService _experienceService;

        public ExperiencesController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("GetAllExperience")]
        public IActionResult GetAll()
        {

            var result = _experienceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdExperience")]
        public IActionResult GetById(int id)
        {
            var result = _experienceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateExperience")]
        public IActionResult Update(Experience experience)
        {
            var result = _experienceService.Update(experience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Experience By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _experienceService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddExperience")]

        public IActionResult Post(Experience experience)
        {
            var result = _experienceService.Add(experience);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
