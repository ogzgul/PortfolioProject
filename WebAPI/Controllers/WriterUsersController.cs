using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterUsersController : ControllerBase
    {
        IWriterUserService _writerUserService;

        public WriterUsersController(IWriterUserService writerUserService)
        {
            _writerUserService = writerUserService;
        }

        [HttpGet("GetAllWriterUser")]
        public IActionResult GetAll()
        {

            var result = _writerUserService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdWriterUser")]
        public IActionResult GetById(int id)
        {
            var result = _writerUserService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateWriterUser")]
        public IActionResult Update(WriterUser writerUser)
        {
            var result = _writerUserService.Update(writerUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete WriterUser By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _writerUserService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddWriterUser")]

        public IActionResult Post(WriterUser writerUser)
        {
            var result = _writerUserService.Add(writerUser);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
