using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var listedPortfolio = _portfolioManager.GetAll().Data;
            return View(listedPortfolio);
        }
    }
}
