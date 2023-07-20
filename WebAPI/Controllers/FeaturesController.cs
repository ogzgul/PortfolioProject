using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet("GetAllFeature")]
        public IActionResult GetAll()
        {

            var result = _featureService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdFeature")]
        public IActionResult GetById(int id)
        {
            var result = _featureService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateFeature")]
        public IActionResult Update(Feature feature)
        {
            var result = _featureService.Update(feature);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Feature By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _featureService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddFeature")]

        public IActionResult Post(Feature feature)
        {
            var result = _featureService.Add(feature);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
