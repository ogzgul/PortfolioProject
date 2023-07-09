using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
