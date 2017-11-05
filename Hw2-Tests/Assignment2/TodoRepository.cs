using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Hw2_Tests.Assignment2;
using Hw1_Tests.Assignment3;

namespace Hw2_Tests.Assignment2
{

    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }
  

        /// Gets TodoItem for a given id
        /// <returns > TodoItem if found , null otherwise </ returns >
        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(todo => todo.Id == todoId);
        }

        /// Adds new TodoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateTodoItemException with the message" duplicate id: {id }".       
        /// <returns > TodoItem that was added </ returns >
        public TodoItem Add(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            throw new DuplicateTodoItemException(String.Format("Duplicate Id: {0}", todoItem.Id));
        }

        /// Tries to remove a TodoItem with given id from the database . 
        /// <returns > True if success , false otherwise </ returns >
        public bool Remove(Guid todoId)
        {
            var todoItem = _inMemoryTodoDatabase.FirstOrDefault(todo => todo.Id == todoId);
            return _inMemoryTodoDatabase.Remove(todoItem);
        }

        /// Updates given TodoItem in the database .
        /// If TodoItem does not exist , method will add one .
        /// <returns > TodoItem that was updated </ returns >
        public TodoItem Update(TodoItem todoItem)
        {
            Remove(todoItem.Id);      
            return Add(todoItem);
        }

        /// Tries to mark a TodoItem as completed in the database .
        /// <returns > True if success , false otherwise </ returns >
        public bool MarkAsCompleted(Guid todoId)
        {
            var todoItem = _inMemoryTodoDatabase.FirstOrDefault(todo => todo.Id == todoId);
            if (todoItem != null)
            {
                todoItem.MarkAsCompleted();
                return true;
            }
            return false;
        }

        /// Gets all TodoItem objects in the database , sorted by date created (descending )      
        public List<TodoItem> GetAll()
        {
            var list = _inMemoryTodoDatabase.OrderByDescending(todo => todo.DateCreated).ToList();
            return list;
        }

        /// Gets all incomplete TodoItem objects in the database
        public List<TodoItem> GetActive()
        {
            var list = _inMemoryTodoDatabase.Where(todo => !todo.IsCompleted).ToList();
            return list;
        }

        
        /// Gets all completed TodoItem objects in the database
        public List<TodoItem> GetCompleted()
        {
            var list = _inMemoryTodoDatabase.Where(todo => todo.IsCompleted).ToList();
            return list;
        }

        /// Gets all TodoItem objects in database that apply to the filter
        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            var list = _inMemoryTodoDatabase.Where(todo => filterFunction(todo)).ToList();
            return list;
        }
    }
}

