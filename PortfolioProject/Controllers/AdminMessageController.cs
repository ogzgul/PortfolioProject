using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace PortfolioProject.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string adminMail = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(adminMail).Data;
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string adminMail = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(adminMail).Data;
            return View(values);
        }

        public IActionResult DeleteWriterMessage(int id)
        {
            var values = _writerMessageManager.GetById(id).Data;
            _writerMessageManager.Delete(values.WriterMessageID);
            return RedirectToAction("SenderMessageList");
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageManager.GetById(id).Data;
            return View(values);
        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "admin";
            writerMessage.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            PortfolioContext c = new PortfolioContext();
            var userNameSurName = c.Users.Where(x => x.Email == writerMessage.Receiver).Select(x => x.Name + "" + x.Surname).FirstOrDefault();
            writerMessage.ReceiverName = userNameSurName;
            _writerMessageManager.Add(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
