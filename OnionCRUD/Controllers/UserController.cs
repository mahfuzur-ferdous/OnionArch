//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ServiceLayer.Service.Contract;
//using DomainLayer.Models;

//namespace OnionCRUD.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUser _user;

//        public UserController(IUser user)
//        {
//            this._user = user;
//        }

//        // GET: api/User/getall
//        [HttpGet("getall")]
//        public ActionResult<List<User>> GetAllUsers()
//        {
//            var users = _user.GetAllRepo();
//            return Ok(users);
//        }

//        // GET: api/User/get/{id}
//        [HttpGet("get/{id}")]
//        public ActionResult<User> GetSingleUser(int id)
//        {
//            var user = _user.GetSingleRepo(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return Ok(user);
//        }

//        // POST: api/User/add
//        [HttpPost("add")]
//        public ActionResult<string> AddUser(User user)
//        {
//            var result = _user.AddUserRepo(user);
//            return Ok(result);
//        }

//        // PUT: api/User/edit/{id}
//        [HttpPut("edit/{id}")]
//        public ActionResult<string> UpdateUser(int id, User user)
//        {
//            if (id != user.userId)
//            {
//                return BadRequest("ID mismatch");
//            }
//            var result = _user.UpdateUserRepo(user);
//            return Ok(result);
//        }

//        // DELETE: api/User/{id}
//        [HttpDelete("{id}")]
//        public ActionResult<string> DeleteUser(int id)
//        {
//            var result = _user.DeleteUserRepo(id);
//            if (result == "User not found")
//            {
//                return NotFound();
//            }
//            return Ok(result);
//        }
//    }
//}