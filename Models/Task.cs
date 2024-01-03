namespace TODO_List{
    
    public enum TaskStatus{
        ToDo,
        Doing,
        Review,
        Done
    }
    
    public class Task{
        private int id;
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
    }


}