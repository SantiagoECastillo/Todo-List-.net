using System.Data.SQLite;
using TODO_List.Models;


namespace TODO_List.Repository{
    public class TaskRepository : ITaskRepository{
        private String connectionString = "Data Source=DB/kanba.db;Cache=Shared";
        public void CreateTask(Tasks task){
            var query = $"INSERT INTO Tarea(id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES(@idBoard, @taskName, @status, @description, @color, @idUser)";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@idBoard", task.IdBoard));
                command.Parameters.Add(new SQLiteParameter("@taskName", task.TaskName));
                command.Parameters.Add(new SQLiteParameter("@status", task.Status));
                command.Parameters.Add(new SQLiteParameter("@description", task.Description));
                command.Parameters.Add(new SQLiteParameter("@color", task.Color));
                command.Parameters.Add(new SQLiteParameter("@idUser", task.AssignedUserId));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateTask(int idTask, Tasks task){
            var query = $"UPDATE Tarea SET id_tablero = @idBoard, nombre = @taskName, estado = @status, descripcion = @description, color = @color, id_usuario_asignado = @idUser, WHERE id = '{idTask}';";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@idBoard", task.IdBoard));
                command.Parameters.Add(new SQLiteParameter("@taskName", task.TaskName));
                command.Parameters.Add(new SQLiteParameter("@status", task.Status));
                command.Parameters.Add(new SQLiteParameter("@description", task.Description));
                command.Parameters.Add(new SQLiteParameter("@color", task.Color));
                command.Parameters.Add(new SQLiteParameter("@idUser", task.AssignedUserId));
                

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Tasks GetTaskById(int idTask){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            var task = new Tasks();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tarea WHERE id = @idUser";
            command.Parameters.Add(new SQLiteParameter("idUser", idTask));

            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    task.IdBoard = Convert.ToInt32(reader["id_tablero"]); 
                    task.TaskName = reader["nombre"].ToString();
                    task.Status = (TaskStatus)Convert.ToInt32(reader["estado"]);
                    task.Description = reader["descripcion"].ToString();
                    task.Color = reader["color"].ToString();
                    task.AssignedUserId = Convert.ToInt32(reader["id_usuario_asignado"]);
                }
            }
            connection.Close();
            
            return task;
        }
        public List<Tasks> GetTaskByUser(int idUser){
            List<Tasks> allTasks = new List<Tasks>();
            var query = $"SELECT * FROM Tarea WHERE id_usuario_asignado = '{idUser}'";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var task = new Tasks();
                        task.IdBoard = Convert.ToInt32(reader["id_tablero"]); 
                        task.TaskName = reader["nombre"].ToString();
                        task.Status = (TaskStatus)Convert.ToInt32(reader["estado"]);
                        task.Description = reader["descripcion"].ToString();
                        task.Color = reader["color"].ToString();
                        task.AssignedUserId = Convert.ToInt32(reader["id_usuario_asignado"]);
                        allTasks.Add(task);
                    }
                }
                connection.Close();
            }
            return allTasks;
        }
        public List<Tasks> GetTaskByBoard(int idBoard){
            List<Tasks> allTasks = new List<Tasks>();
            var query = $"SELECT * FROM Tarea WHERE id_tablero = '{idBoard}'";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var task = new Tasks();
                        task.IdBoard = Convert.ToInt32(reader["id_tablero"]); 
                        task.TaskName = reader["nombre"].ToString();
                        task.Status = (TaskStatus)Convert.ToInt32(reader["estado"]);
                        task.Description = reader["descripcion"].ToString();
                        task.Color = reader["color"].ToString();
                        task.AssignedUserId = Convert.ToInt32(reader["id_usuario_asignado"]);
                        allTasks.Add(task);
                    }
                }
                connection.Close();
            }
            return allTasks;
        }
        public void DeleteTask(int idTask){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Tarea WHERE id = @idTask";
            command.Parameters.Add(new SQLiteParameter("@idTask", idTask));  
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AssignUserTask(int idUser, int idTask){
            var query = $"UPDATE Tarea SET (id_usuario_asignado) VALUES () WHERE id = '{idTask}';";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idAssignedUser", idUser));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}