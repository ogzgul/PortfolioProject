using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class ProjectList:ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var listedPortfolio = portfolioManager.GetAll().Data;

            return View(listedPortfolio);
        }
    }
}
