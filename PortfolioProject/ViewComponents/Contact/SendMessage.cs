using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PortfolioProject.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            var listedMessage = _messageManager.GetAll().Data;
            return View(listedMessage);
        }
       
    }
}
