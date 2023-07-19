using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PortfolioProject.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager _userManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(_userManager.GetAll().Data);
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterUser writerUser)
        {
            _userManager.Add(writerUser);
            var values = JsonConvert.SerializeObject(writerUser);
            return Json(values);
        }
    }
}
