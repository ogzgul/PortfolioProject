using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class Last5Project:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
