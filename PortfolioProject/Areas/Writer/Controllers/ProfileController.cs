using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string b)
        {
            return View();
        }
    }
}
