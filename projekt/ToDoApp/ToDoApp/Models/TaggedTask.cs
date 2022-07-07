namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of TaggedTask
    /// </summary>
    public class TaggedTask
    {
        /// <summary>
         /// ID - int, not null, primary key
         /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TaskId - Int, not null, forgien key <see cref="Task" />
        /// </summary>
        public int TaskId { get; set; }
        /// <summary>
        /// Task - reference forgien key <see cref="Task" />
        /// </summary>
        public Task Task { get; set; }
        /// <summary>
        /// TagId - Int, not null, forgien key <see cref="Tag" />
        /// </summary>
        public int TagId { get; set; }
        /// <summary>
        /// Tag - reference forgien key <see cref="Tag" />
        /// </summary>
        public Tag Tag { get; set; }
    }
}