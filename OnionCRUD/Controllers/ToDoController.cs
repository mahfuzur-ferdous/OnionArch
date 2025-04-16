
    using Microsoft.AspNetCore.Mvc;
    using DomainLayer.Models;
    using ServiceLayer.Service.Contract;
    using System.Collections.Generic;

    namespace OnionCRUD.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ToDoController : ControllerBase
        {
            private readonly ITodo _todo;

            public ToDoController(ITodo todo)
            {
                _todo = todo;
            }

            // GET: api/ToDo/getall
            [HttpGet("getall")]
            public ActionResult<List<TodoItems>> GetAllTodos()
            {
                var todos = _todo.GetAllRepo();
                return Ok(todos);
            }

            // GET: api/ToDo/get/{id}
            [HttpGet("get/{id}")]
            public ActionResult<TodoItems> GetSingleTodo(int id)
            {
                var todo = _todo.GetSingleRepo(id);
                if (todo == null)
                {
                    return NotFound();
                }
                return Ok(todo);
            }

            // POST: api/ToDo/add
            [HttpPost("add")]
            public ActionResult<string> AddTodo(TodoItems todo)
        {
                var result = _todo.AddTodoRepo(todo);
                return Ok(result);
            }

            // PUT: api/ToDo/edit/{id}
            [HttpPut("edit/{id}")]
            public ActionResult<string> UpdateTodo(int id, TodoItems todo)
            {
                if (id != todo.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var result = _todo.UpdateTodoRepo(todo);
                return Ok(result);
            }

            // DELETE: api/ToDo/{id}
            [HttpDelete("{id}")]
            public ActionResult<string> DeleteTodo(int id)
            {
                var result = _todo.DeleteTodoRepo(id);
                if (result == "Todo not found")
                {
                    return NotFound();
                }

                return Ok(result);
            }
        }
    }


