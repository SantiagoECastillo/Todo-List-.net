using TODO_List.Models;

namespace TODO_List.Repository{
    public interface IUserRepository{
        public void CreateUser(User user);
        public void UpdateUser(int id, User user);
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public void DeleteUser(int id);
    }
}
