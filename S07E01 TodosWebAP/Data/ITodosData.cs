using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using S04E02_Todo.Models;

namespace S04E02_Todo.Data
{
    public interface ITodosData
    {
        Task<IList<Todo>> GetTodosAsync();
        Task<Todo> AddTodoAsync(Todo todo);
        Task<Todo> RemoveTodoAsync(int todoId);
        Task<Todo> UpdateAsync(Todo todo);
        Task<Todo> GetAsync(int id);
        Task<IList<Todo>> GetTodosByIsCompletedAsync(bool isCompleted);
    }
}