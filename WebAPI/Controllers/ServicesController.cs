using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("GetAllService")]
        public IActionResult GetAll()
        {

            var result = _serviceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdService")]
        public IActionResult GetById(int id)
        {
            var result = _serviceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateService")]
        public IActionResult Update(Service service)
        {
            var result = _serviceService.Update(service);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Service By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _serviceService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddService")]

        public IActionResult Post(Service service)
        {
            var result = _serviceService.Add(service);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
