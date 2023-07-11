using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TodoListManager : ITodoListService
    {
        ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public IResult Add(TodoList todoList)
        {
            _todoListDal.Add(todoList);
            return new SuccessResult(Messages.TodoListAdded);
        }

        public IResult Delete(int id)
        {
            var deletedTodoList = _todoListDal.Get(x => x.TodoID == id);
            _todoListDal.Delete(deletedTodoList);
            return new SuccessResult($"Deleted todo: {id} number's {Messages.TodoListDeleted}");
        }

        public IDataResult<List<TodoList>> GetAll()
        {
            var listedTodoList = _todoListDal.GetAll();
            return new SuccessDataResult<List<TodoList>>(listedTodoList, Messages.TodoListGetAll);
        }

        public IDataResult<TodoList> GetById(int todoListId)
        {
            var listTodoListGetById = _todoListDal.Get(x => x.TodoID == todoListId);
            return new SuccessDataResult<TodoList>(listTodoListGetById, Messages.TodoListGetById);
        }

        public IResult Update(TodoList todoList)
        {
            var updateTodoList = _todoListDal.Get(x => x.TodoID == todoList.TodoID);
            TodoList updatedTodoList = new TodoList()
            {
                TodoID = todoList.TodoID,
                Content=todoList.Content,
                Status=todoList.Status
            };
            _todoListDal.Update(updatedTodoList);
            return new SuccessResult(Messages.TodoListUpdated);
        }
    }
}
