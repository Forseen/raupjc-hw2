using System;
using System.Collections.Generic;
using System.Text;
using Hw2_Tests.Assignment2;

namespace Hw2_Tests.Assignment2
{
    public interface ITodoRepository
    {
    
        /// Gets TodoItem for a given id
        /// <returns > TodoItem if found , null otherwise </ returns >
        TodoItem Get(Guid todoId);
            
        /// Adds new TodoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateTodoItemException with the message" duplicate id: {id }".       
        /// <returns > TodoItem that was added </ returns >
        TodoItem Add(TodoItem todoItem);
 
        /// Tries to remove a TodoItem with given id from the database . 
        /// <returns > True if success , false otherwise </ returns >
        bool Remove(Guid todoId);
       
        /// Updates given TodoItem in the database .
        /// If TodoItem does not exist , method will add one .
        /// <returns > TodoItem that was updated </ returns >
        TodoItem Update(TodoItem todoItem);
       
        /// Tries to mark a TodoItem as completed in the database .
        /// <returns > True if success , false otherwise </ returns >
        bool MarkAsCompleted(Guid todoId);
        
        /// Gets all TodoItem objects in the database , sorted by date created (descending )      
        List<TodoItem> GetAll ();
        
        /// Gets all incomplete TodoItem objects in the database
        List<TodoItem> GetActive();

        /// <summary >
        /// Gets all completed TodoItem objects in the database
        /// </ summary >
        List<TodoItem> GetCompleted();
        
        /// Gets all TodoItem objects in database that apply to the filter
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }
}
