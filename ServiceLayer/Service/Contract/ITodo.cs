using DomainLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Service.Contract
{
    public interface ITodo
    {
        List<TodoItems> GetAllRepo();
        TodoItems GetSingleRepo(int id);
        string AddTodoRepo(TodoItems todo);
        string UpdateTodoRepo(TodoItems todo);
        string DeleteTodoRepo(int id);
    }
}
