using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("GetAllAbout")]
        public IActionResult GetAll()
        {
            
            var result = _aboutService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdAbout")]
        public IActionResult GetById(int id)
        {
            var result = _aboutService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateAbout")]
        public IActionResult Update(About about)
        {
            var result = _aboutService.Update(about);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete About By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _aboutService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddAbout")]

        public IActionResult Post(About about)
        {
            var result = _aboutService.Add(about);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
