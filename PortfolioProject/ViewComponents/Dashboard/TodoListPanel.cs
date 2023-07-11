using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioProject.ViewComponents.Dashboard
{
    public class TodoListPanel:ViewComponent
    {
        TodoListManager todoListManager = new TodoListManager(new EfTodoListDal());
        public IViewComponentResult Invoke()
        {
            var listedTodoList= todoListManager.GetAll().Data;
            return View(listedTodoList);
        }
    }
}
