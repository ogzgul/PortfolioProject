using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {
            var editSkill = featureManager.GetById(1).Data;
            return View(editSkill);
        }


        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.Update(feature);
            return RedirectToAction("Index","Default");
        }
    }
}
