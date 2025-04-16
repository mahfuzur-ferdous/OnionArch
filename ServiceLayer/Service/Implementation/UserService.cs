//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DomainLayer.Models;
//using Microsoft.EntityFrameworkCore;
//using RepositoryLayer;
//using ServiceLayer.Service.Contract;

//namespace ServiceLayer.Service.Implementation
//{
//    public class UserService : IUser
//    {
//        private readonly AppDbContext _dbContext;
//        public UserService(AppDbContext DbContext)
//        {
//            _dbContext = DbContext;
//        }

//        public string AddUserRepo(User user) 
//        {
//            try
//            {
//                _dbContext.users.Add(user);
//                _dbContext.SaveChanges();
//                return "User added successfully";
//            }
//            catch (Exception ex)
//            {
//                return $"Error adding user: {ex.Message}";
//            }
//        }

//        public string DeleteUserRepo(int id)
//        {
//            try
//            {
//                var userToDelete = _dbContext.users.Find(id);
//                if (userToDelete != null)
//                {
//                    _dbContext.users.Remove(userToDelete);
//                    _dbContext.SaveChanges();
//                    return "User deleted successfully";
//                }
//                else
//                {
//                    return "User not found";
//                }
//            }
//            catch (Exception ex)
//            {
//                return $"Error deleting user: {ex.Message}";
//            }
//        }

//        //Get All User
//        public List<User> GetAllRepo()
//        {
//            return _dbContext.users.ToList();
//        }

//        //Get Single User
//        public User GetSingleRepo(int id)
//        {
//            return _dbContext.users.Find(id);
//        }

//        public string UpdateUserRepo(User user)
//        {
//            try
//            {
//                _dbContext.users.Update(user);
//                _dbContext.SaveChanges();
//                return "User updated successfully";
//            }
//            catch (Exception ex)
//            {
//                return $"Error updating user: {ex.Message}";
//            }
//        }
//    }
//}