using TODO_List.Models;


namespace TODO_List.Repository{
    public interface ITaskRepository{
        public void CreateTask(Tasks task);
        public void UpdateTask(int idTask, Tasks task);
        public Tasks GetTaskById(int idTask);
        public List<Tasks> GetTaskByUser(int idUser);
        public List<Tasks> GetTaskByBoard(int idBoard);
        public void DeleteTask(int idTask);
        public void AssignUserTask(int idUser, int idTask);
    }
}