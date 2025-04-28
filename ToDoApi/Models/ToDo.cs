namespace ToDoApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int CompletePercent { get; set; }
        public DateTime Expiration { get; set; }
    }
}
