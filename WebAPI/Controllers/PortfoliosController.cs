using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("GetAllPortfolio")]
        public IActionResult GetAll()
        {

            var result = _portfolioService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdPortfolio")]
        public IActionResult GetById(int id)
        {
            var result = _portfolioService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdatePortfolio")]
        public IActionResult Update(Portfolio portfolio)
        {
            var result = _portfolioService.Update(portfolio);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete Portfolio By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _portfolioService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddPortfolio")]

        public IActionResult Post(Portfolio portfolio)
        {
            var result = _portfolioService.Add(portfolio);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
