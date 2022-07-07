using System;

namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of Task
    /// </summary>
    public class Task
    {
        /// <summary>
        /// ID - int, not null, primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name - string, not null
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Date - DateTime, null
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// StatusId - Int, not null, forgien key <see cref="Status" />
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Status - reference forgien key <see cref="Status" />
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// UserId - Int, not null, forgien key <see cref="User" />
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User - reference forgien key <see cref="User" />
        /// </summary>
        public User User { get; set; }
    }
}