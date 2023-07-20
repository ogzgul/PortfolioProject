using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet("GetAllSocialMedia")]
        public IActionResult GetAll()
        {

            var result = _socialMediaService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdSocialMedia")]
        public IActionResult GetById(int id)
        {
            var result = _socialMediaService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateSocialMedia")]
        public IActionResult Update(SocialMedia socialMedia)
        {
            var result = _socialMediaService.Update(socialMedia);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete SocialMedia By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _socialMediaService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddSocialMedia")]

        public IActionResult Post(SocialMedia socialMedia)
        {
            var result = _socialMediaService.Add(socialMedia);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
