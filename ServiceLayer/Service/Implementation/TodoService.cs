using System;
using System.Collections.Generic;
using System.Linq;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Service.Contract;

namespace ServiceLayer.Service.Implementation
{
    public class TodoService : ITodo
    {
        private readonly AppDbContext _dbContext;

        public TodoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add Todo
        public string AddTodoRepo(TodoItems todo)
        {
            try
            {
                _dbContext.todoitems.Add(todo);
                _dbContext.SaveChanges();
                return "Todo added successfully";
            }
            catch (Exception ex)
            {
                return $"Error adding todo: {ex.Message}";
            }
        }

        // Delete Todo
        public string DeleteTodoRepo(int id)
        {
            try
            {
                var todoToDelete = _dbContext.todoitems.Find(id);
                if (todoToDelete != null)
                {
                    _dbContext.todoitems.Remove(todoToDelete);
                    _dbContext.SaveChanges();
                    return "Todo deleted successfully";
                }
                else
                {
                    return "Todo not found";
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting todo: {ex.Message}";
            }
        }

        // Get All Todos
        public List<TodoItems> GetAllRepo()
        {
            return _dbContext.todoitems
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        // Get Single Todo
        public TodoItems GetSingleRepo(int id)
        {
            return _dbContext.todoitems.Find(id);
        }

        // Update Todo
        public string UpdateTodoRepo(TodoItems todo)
        {
            try
            {
                _dbContext.todoitems.Update(todo);
                _dbContext.SaveChanges();
                return "Todo updated successfully";
            }
            catch (Exception ex)
            {
                return $"Error updating todo: {ex.Message}";
            }
        }
    }
}
