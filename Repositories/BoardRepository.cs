using System.Data.SQLite;
using TODO_List.Models;

namespace TODO_List.Repository{
    public class BoardRepository : IBoardRepository{
        private String connectionString = "Data Source=DB/kanba.db;Cache=Shared";
        public void CreateBoard(Board board){
            var query = $"INSERT INTO Tablero(id_usuario_propietario, nombre, descripcion) VALUES(@ownerUser, @boardName, @description)";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@ownerUser", board.OwnerUserId));
                command.Parameters.Add(new SQLiteParameter("@boardName", board.BoardName));
                command.Parameters.Add(new SQLiteParameter("@description", board.Description));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void UpdateBoard(int id, Board board){
            var query = $"UPDATE Tablero SET  id_usuario_propietario = @userName, nombre = @boardName, descripcion = @description WHERE id = '{id}';";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@ownerUser", board.OwnerUserId));
                command.Parameters.Add(new SQLiteParameter("@boardName", board.BoardName));
                command.Parameters.Add(new SQLiteParameter("@description", board.Description));

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public Board GetBoardById(int id){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            var board = new Board();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tablero WHERE id = @idBoard";
            command.Parameters.Add(new SQLiteParameter("@idBoard", id));  
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    board.OwnerUserId = Convert.ToInt32(reader["id_usuario_propietario"]);
                    board.BoardName = reader["nombre"].ToString(); 
                    board.Description = reader["descripcion"].ToString();
                }
            }
            connection.Close();
            
            return board;
        }
        public List<Board> GetAllBoards(){
            List<Board> allBoards = new List<Board>();
            var query = $"SELECT * FROM Tablero";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var board = new Board();
                        board.Id = Convert.ToInt32(reader["id"]);
                        board.OwnerUserId = Convert.ToInt32(reader["id_usuario_propietario"]);
                        board.BoardName = reader["nombre"].ToString();
                        board.Description = reader["descripcion"].ToString(); 
                        allBoards.Add(board);
                    }
                }
                connection.Close();
            }
            return allBoards;
        }
        public List<Board> GetBoardsByUser(int idUser){
            List<Board> allBoards = new List<Board>();
            var query = $"SELECT * FROM Tablero WHERE id_usuario_propietario = '{idUser}'";
            using(SQLiteConnection connection = new SQLiteConnection(connectionString)){
                var command = new SQLiteCommand(query, connection);
                connection.Open();

                using(SQLiteDataReader reader = command.ExecuteReader()){
                    while(reader.Read()){
                        var board = new Board();
                        board.Id = Convert.ToInt32(reader["id"]);
                        board.OwnerUserId = Convert.ToInt32(reader["id_usuario_propietario"]);
                        board.BoardName = reader["nombre"].ToString();
                        board.Description = reader["descripcion"].ToString(); 
                        allBoards.Add(board);
                    }
                }
                connection.Close();
            }
            return allBoards;
        }
        public void DeteleBoard(int id){
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Tablero WHERE id = @idBoard";
            command.Parameters.Add(new SQLiteParameter("@idBoard", id));  
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
