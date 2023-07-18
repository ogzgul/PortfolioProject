using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values= _messageManager.GetAll().Data;
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = _messageManager.GetById(id).Data;
            _messageManager.Delete(values.MessageID);
            return RedirectToAction("Index");
        }

        public IActionResult ContactDetails(int id)
        {
            var values = _messageManager.GetById(id).Data;
            return View(values);
        }
    }
}
