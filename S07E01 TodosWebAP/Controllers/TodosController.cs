using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using S04E02_Todo.Data;
using S04E02_Todo.Models;

namespace S07E01_TodosWebAP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private ITodosData todoService;

        public TodosController(ITodosData todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Todo>>> GetTodos([FromQuery] bool? isCompleted, [FromQuery] int? userId)
        {
            try
            {
                IList<Todo> todos;
                if (isCompleted == null && userId == null)
                {
                    todos = await todoService.GetTodosAsync();
                }
                //filter by userId
                else if (isCompleted == null)
                {
                    Todo todoOfId = await todoService.GetAsync(userId.Value);
                    todos = new List<Todo>();
                    todos.Add(todoOfId);
                }
                //filter by isCompleted
                else if (userId == null)
                {
                    todos = await todoService.GetTodosByIsCompletedAsync(isCompleted.Value);
                }
                //filter by both
                else if (todoService.GetAsync(userId.Value).IsCompleted == isCompleted)
                {
                    //this userId has this isCompleted -> only this userId
                    Todo todoOfId = await todoService.GetAsync(userId.Value);
                    todos = new List<Todo>();
                    todos.Add(todoOfId);
                }
                else
                {
                    //userId does not have this isCompleted -> 0 results
                    todos = new List<Todo>();
                }
                

                return Ok(todos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> AddTodo([FromBody] Todo todo)
        {
            try
            {
                Todo added = await todoService.AddTodoAsync(todo);
                return Created($"/{added.TodoId}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteTodo([FromRoute] int id)
        {
            try
            {
                Todo deleted = await todoService.RemoveTodoAsync(id);
                return Ok($"Deleted todo {deleted}"); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Todo>> PatchTodo([FromBody] Todo todo)
        {
            try
            {
                Todo patched = await todoService.UpdateAsync(todo);
                return Ok($"Updated todo {patched}"); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}