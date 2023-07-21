using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = messageManager.GetAll().Data.Take(5).ToList();
            var valuess = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = valuess.ImageUrl;
            return View(values);
        }
    }
}
