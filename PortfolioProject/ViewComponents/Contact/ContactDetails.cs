using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var listedContact = _contactManager.GetAll().Data;
            return View(listedContact);
        }
    }
}
