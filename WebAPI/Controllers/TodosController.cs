using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        ITodoListService _todoListService;

        public TodosController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet("GetAllTodoList")]
        public IActionResult GetAll()
        {

            var result = _todoListService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByIdTodoList")]
        public IActionResult GetById(int id)
        {
            var result = _todoListService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateTodoList")]
        public IActionResult Update(TodoList todoList)
        {
            var result = _todoListService.Update(todoList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete TodoList By Id")]

        public IActionResult DeleteById(int id)
        {
            var result = _todoListService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost("AddTodoList")]

        public IActionResult Post(TodoList todoList)
        {
            var result = _todoListService.Add(todoList);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
