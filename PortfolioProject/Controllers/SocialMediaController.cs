using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = _socialMediaManager.GetAll().Data;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            _socialMediaManager.Add(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var result = _socialMediaManager.GetById(id);
            var socialMedia = result.Data;
            _socialMediaManager.Delete(socialMedia.SocialMediaID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var editSocialMedia = _socialMediaManager.GetById(id).Data;
            return View(editSocialMedia);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaManager.Update(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
