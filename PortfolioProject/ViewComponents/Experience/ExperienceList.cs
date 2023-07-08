using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperienceDal());

        public IViewComponentResult Invoke()
        {
            var listedExperience = _experienceManager.GetAll().Data;
            return View(listedExperience);
        }
    }
}
