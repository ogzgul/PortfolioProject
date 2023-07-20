using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetAllMessage")]
        public IActionResult GetAll()
        {

            var result = _messageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdMessage")]
        public IActionResult GetById(int id)
        {
            var result = _messageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateMessage")]
        public IActionResult Update(Message message)
        {
            var result = _messageService.Update(message);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Message By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _messageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddMessage")]

        public IActionResult Post(Message message)
        {
            var result = _messageService.Add(message);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
