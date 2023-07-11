using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
