using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            var listedExperience = experienceManager.GetAll().Data;
            return View(listedExperience);
        }
        [HttpGet]
        public IActionResult AddExperience() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.Add(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.GetById(id).Data;
            experienceManager.Delete(values.ExperienceID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            var editExperience = experienceManager.GetById(id).Data;
            return View(editExperience);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.Update(experience);
            return RedirectToAction("Index");
        }
    }
}
