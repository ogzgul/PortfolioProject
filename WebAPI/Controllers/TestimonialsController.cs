using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet("GetAllTestimonial")]
        public IActionResult GetAll()
        {

            var result = _testimonialService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdTestimonial")]
        public IActionResult GetById(int id)
        {
            var result = _testimonialService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateTestimonial")]
        public IActionResult Update(Testimonial testimonial)
        {
            var result = _testimonialService.Update(testimonial);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Testimonial By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _testimonialService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddTestimonial")]

        public IActionResult Post(Testimonial testimonial)
        {
            var result = _testimonialService.Add(testimonial);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
