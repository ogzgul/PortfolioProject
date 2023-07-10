using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PortfolioProject.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Messages.Where(x=>x.Status==false).Count();
            ViewBag.v3=context.Messages.Where(x=>x.Status==true).Count();
            ViewBag.v4=context.Experiences.Count();
            return View();
        }
    }
}
