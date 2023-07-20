using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("GetAllAnnouncement")]
        public IActionResult GetAll()
        {

            var result = _announcementService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdAnnouncement")]
        public IActionResult GetById(int id)
        {
            var result = _announcementService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateAnnouncement")]
        public IActionResult Update(Announcement announcement)
        {
            var result = _announcementService.Update(announcement);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Announcement By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _announcementService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddAnnouncement")]

        public IActionResult Post(Announcement announcement)
        {
            var result = _announcementService.Add(announcement);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
