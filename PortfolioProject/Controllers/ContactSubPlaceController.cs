using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            var listContact = _contactManager.GetById(1).Data;
            return View(listContact);
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactManager.Update(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
