namespace TODO_List.Models{
    
    public enum TasksStatus{
        ToDo,
        Doing,
        Review,
        Done
    }
    
    public class Tasks{
        private int id;
        private int idBoard;
        private String? taskName;
        private String? description;
        private String? color;
        private TaskStatus status;
        private int assignedUserId;

        public int Id { get => id; set => id = value; }
        public string? TaskName { get => taskName; set => taskName = value; }
        public string? Description { get => description; set => description = value; }
        public string? Color { get => color; set => color = value; }
        public TaskStatus Status { get => status; set => status = value; }
        public int AssignedUserId { get => assignedUserId; set => assignedUserId = value; }
        public int IdBoard { get => idBoard; set => idBoard = value; }
    }


}