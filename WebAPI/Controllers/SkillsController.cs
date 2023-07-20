using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("GetAllSkill")]
        public IActionResult GetAll()
        {

            var result = _skillService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdSkill")]
        public IActionResult GetById(int id)
        {
            var result = _skillService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateSkill")]
        public IActionResult Update(Skill skill)
        {
            var result = _skillService.Update(skill);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Skill By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _skillService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddSkill")]

        public IActionResult Post(Skill skill)
        {
            var result = _skillService.Add(skill);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
