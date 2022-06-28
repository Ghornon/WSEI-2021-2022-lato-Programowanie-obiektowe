using System;

namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of Task
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}