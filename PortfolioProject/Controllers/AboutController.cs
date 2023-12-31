﻿using Business.Concrete;
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
            var listAbout = aboutManager.GetById(1).Data;
            return View(listAbout);
        }


        [HttpPost]
        public IActionResult Index(About about)
        {
            aboutManager.Update(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
