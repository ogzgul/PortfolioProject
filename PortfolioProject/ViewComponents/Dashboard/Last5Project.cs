using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class Last5Project:ViewComponent
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = _portfolioManager.GetAll().Data.Take(5).ToList();
            return View(values);
        }
    }
}
