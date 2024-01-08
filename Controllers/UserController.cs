
using Microsoft.AspNetCore.Mvc;
using TODO_List.Repository;

namespace TODO_List.Controllers{

    public class UserController : Controller {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        
        public UserController(ILogger<UserController> logger){
            _logger = logger;
            _userRepository = new UserRepository();           
        }


        public IActionResult GetUser(){
            var users = _userRepository.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser(){
            return View(new User());
        }

        
        [HttpPost]
        public IActionResult CreateUser(User user){
            _userRepository.CreateUser(user);
            return RedirectToAction("GetUser");
        }

        [HttpGet]
        public IActionResult UpdateUser(int idUser){
            var user = _userRepository.GetUserById(idUser);
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(User user){
            var modifiedUser = _userRepository.GetUserById(user.Id);
            modifiedUser.UserName = user.UserName;
            _userRepository.UpdateUser(user.Id, modifiedUser);
            return RedirectToAction("GetUser");
        }

        [HttpPost]
        public IActionResult DeleteUser(int id){
            _userRepository.DeleteUser(id);
            return RedirectToAction("GetUser");
        }

    }

}