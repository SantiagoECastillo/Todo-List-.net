using TODO_List.Models;

namespace TODO_List.Repository{
    public interface IBoardRepository{
        public void CreateBoard(Board board);
        public void UpdateBoard(int id, Board board);
        public Board GetBoardById(int id);
        public List<Board> GetAllBoards();
        public List<Board> GetBoardsByUser(int idUser);
        public void DeteleBoard(int id);
    }
}
