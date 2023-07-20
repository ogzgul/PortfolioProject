using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriteMessagesController : ControllerBase
    {
        IWriterMessageService _writerMessageService;

        public WriteMessagesController(IWriterMessageService writerMessageService)
        {
            _writerMessageService = writerMessageService;
        }

        [HttpGet("GetAllWriterMessage")]
        public IActionResult GetAll()
        {

            var result = _writerMessageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdWriterMessage")]
        public IActionResult GetById(int id)
        {
            var result = _writerMessageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateWriterMessage")]
        public IActionResult Update(WriterMessage writerMessage)
        {
            var result = _writerMessageService.Update(writerMessage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete WriterMessage By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _writerMessageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddWriterMessage")]

        public IActionResult Post(WriterMessage writerMessage)
        {
            var result = _writerMessageService.Add(writerMessage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
