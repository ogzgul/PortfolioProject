using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Güncelleme";
            var editSkill = aboutManager.GetById(1).Data;
            return View(editSkill);
        }


        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.Update(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
