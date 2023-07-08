using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var listedService = _serviceManager.GetAll().Data;
            return View(listedService);
        }
    
    }
}
