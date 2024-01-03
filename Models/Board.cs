namespace TODO_List{
    public class Board{
        private int id;
        private int ownerUserId;
        private String? boardName;
        private string? description;

        public int Id { get => id; set => id = value; }
        public int OwnerUserId { get => ownerUserId; set => ownerUserId = value; }
        public string? BoardName { get => boardName; set => boardName = value; }
        public string? Description { get => description; set => description = value; }
    }
}