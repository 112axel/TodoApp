using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TodoService
    {
        private FakeDataBase dataBase { get; set; }
        public TodoService(FakeDataBase db)
        {
            dataBase = db;
        }

        public List<TodoItem> GetTodoItems()
        {
            return dataBase.TodoItems;
        }

        public TodoItem CreateNewTodo(TodoItem? item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            dataBase.TodoItems.Add(item);
            return item;
        }

        public void RemoveTodo(string v)
        {
            throw new NotImplementedException();
        }
    }
}
