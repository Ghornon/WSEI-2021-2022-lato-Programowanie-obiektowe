namespace ToDoApp.Models
{
    public class TaggedTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}