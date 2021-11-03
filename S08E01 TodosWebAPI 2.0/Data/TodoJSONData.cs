using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Models;

namespace S04E02_Todo.Data
{
    public class TodoJSONData : ITodosData
    {

        private string todoFile = "todos.json";
        private IList<Todo> todos;

        public TodoJSONData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                WriteTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                todos = JsonSerializer.Deserialize<List<Todo>>(content);
            }
        }

        private void Seed()
        {
            Todo[] ts =
            {
                new Todo
                {
                    UserId = 1,
                    TodoId = 1,
                    Title = "Do dishes",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 1,
                    TodoId = 2,
                    Title = "Walk the dog",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 2,
                    TodoId = 3,
                    Title = "Do DNP homework",
                    IsCompleted = true
                },
                new Todo
                {
                    UserId = 3,
                    TodoId = 4,
                    Title = "Eat breakfast",
                    IsCompleted = false
                },
                new Todo
                {
                    UserId = 4,
                    TodoId = 5,
                    Title = "Mow lawn",
                    IsCompleted = true
                },
            };
            todos = ts.ToList();
        }
        
        public async Task<IList<Todo>> GetTodosAsync()
        {
            List<Todo> tmp = new List<Todo>(todos);
            return tmp;
        }

        public async Task<Todo>  AddTodoAsync(Todo todo)
        {
            int max = todos.Max(todo => todo.TodoId);
            todo.TodoId = (++max);
            todos.Add(todo);
            WriteTodosToFile();
            return todo;
        }

        public async Task RemoveTodoAsync(int todoId)
        {
            Todo toRemove = todos.First(t => t.TodoId == todoId);
            todos.Remove(toRemove);
            WriteTodosToFile();
        }

        public async Task<Todo> UpdateAsync(Todo todo)
        {
            Todo toUpdate = todos.First(t => t.TodoId == todo.TodoId);
            toUpdate.IsCompleted = todo.IsCompleted;
            toUpdate.Title = todo.Title;
            WriteTodosToFile();
            return toUpdate;
        }

        public async Task<Todo> GetAsync(int id)
        {
            return todos.FirstOrDefault(t => t.UserId == id);
        }

        public async Task<IList<Todo>> GetTodosByIsCompletedAsync(bool isCompleted)
        {
            IList<Todo> allTodos = await GetTodosAsync();
            IList<Todo> tmp = new List<Todo>();
            for (int i = 0; i < allTodos.Count; i++)
            {
                if (allTodos[i].IsCompleted == isCompleted)
                {
                    tmp.Add(allTodos[i]);
                }
            }

            return tmp;
        }

        private void WriteTodosToFile()
        {
            string todoAsJason = JsonSerializer.Serialize(todos);
                        File.WriteAllText(todoFile, todoAsJason);
        }
    }
}