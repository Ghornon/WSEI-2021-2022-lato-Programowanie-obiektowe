namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of Tag
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// ID - int, not null, primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name - string, not null
        /// </summary>
        public string Name { get; set; }
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