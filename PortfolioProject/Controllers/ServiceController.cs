using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
       
        public IActionResult Index()
        {
            var listedSkill = serviceManager.GetAll().Data;
            return View(listedSkill);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.Add(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var result = serviceManager.GetById(id);
            var service = result.Data;
            serviceManager.Delete(service.ServiceID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var editService = serviceManager.GetById(id).Data;
            return View(editService);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.Update(service);
            return RedirectToAction("Index");
        }
    }
}
