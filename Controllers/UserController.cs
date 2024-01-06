
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

        [Route("Index")]
        public IActionResult Index(){
            var users = _userRepository.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        [Route("CreateUser")]
        public IActionResult CreateUser(){
            return View(new User());
        }

        
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(User user){
            _userRepository.CreateUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(int idUser){
            var user = _userRepository.GetUserById(idUser);
            return View(user);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user){
            var modifiedUser = _userRepository.GetUserById(user.Id);
            modifiedUser.UserName = user.UserName;
            _userRepository.UpdateUser(user.Id, modifiedUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id){
            _userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }

}