using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Areas.Writer.Controllers
{
    public class DefaultController : Controller
    {
        [Area("Writer")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
