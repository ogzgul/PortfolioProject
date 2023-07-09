﻿using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager= new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";
            var listedSkill = skillManager.GetAll().Data;
            return View(listedSkill);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.Add(skill);
            return RedirectToAction("Index");
        }
       
        public IActionResult DeleteSkill(int id)
        {
            var result = skillManager.GetById(id);
            var skill = result.Data;
            skillManager.Delete(skill.SkillID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Güncelleme";
            var editSkill=skillManager.GetById(id).Data;
            return View(editSkill);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.Update(skill);
            return RedirectToAction("Index");
        }
        
    }
}
