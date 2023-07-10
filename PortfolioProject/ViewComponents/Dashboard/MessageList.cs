using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
