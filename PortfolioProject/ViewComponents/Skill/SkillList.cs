using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        SkillManager _skillManager = new SkillManager(new EfSkillDal());
        public IViewComponentResult Invoke()
        {
            var listedSkill = _skillManager.GetAll().Data;
            return View(listedSkill);
        }
    }
}
