using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        PortfolioContext portfolioContext = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = portfolioContext.Portfolios.Count();
            ViewBag.v2=portfolioContext.Messages.Count();
            ViewBag.v3=portfolioContext.Services.Count();
            return View();
        }
    }
}
