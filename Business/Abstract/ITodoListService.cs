using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITodoListService
    {
        IDataResult<List<TodoList>> GetAll();
        IDataResult<TodoList> GetById(int todoListId);
        IResult Add(TodoList todoList);
        IResult Update(TodoList todoList);
        IResult Delete(int id);
    }
}
