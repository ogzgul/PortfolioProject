using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        UserMessageManager userMessage = new UserMessageManager(new EfUserMessageDal());
        public IViewComponentResult Invoke()
        {
            var listedUserMessage = userMessage.GetUserMessagesWithUserService();
            return View(listedUserMessage);
        }
    }
}
