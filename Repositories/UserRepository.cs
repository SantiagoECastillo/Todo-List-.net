using System.Data.SQLite;
using Microsoft.VisualBasic;
using TODO_List.Models;

namespace TODO_List.Repository{
    public class UserRepository : IUserRepository{
        
        private String connectionString = "Data Source=DB/kanba.db;Cache=Shared";
        
        public void CreateUser(User user){
            var query = $"INSERT INTO Usuario(nombre_de_usuario) VALUES(@userName)";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@userName", user.UserName));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateUser(int id, User user){
            var query = $"UPDATE Usuario SET nombre_de_usuario = @userName  WHERE id = '{id}';";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@userName", user.UserName));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<User> GetAllUsers(){
            List<User> allUsers = new List<User>();
            var query = $"SELECT * FROM Usuario";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var user = new User();
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.UserName = reader["nombre_de_usuario"].ToString();
                        allUsers.Add(user);
                    }
                }
                connection.Close();
            }
            return allUsers;
        }
        public User GetUserById(int id){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            var user = new User();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Usuario WHERE id = @idUser";
            command.Parameters.Add(new SQLiteParameter("idUser", id));  
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.UserName = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();
            
            return user;
        }
        public void DeleteUser(int id){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Usuario WHERE id = @idUser";
            command.Parameters.Add(new SQLiteParameter("idUser", id));  
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
