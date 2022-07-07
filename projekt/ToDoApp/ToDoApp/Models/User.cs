namespace ToDoApp.Models
{
    /// <summary>
    ///   Model of User
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID - int, not null, primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Login - string, not null
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Password - string, not null
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Name - string [A-Z], not null
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Email - string, not null
        /// </summary>
        public string Email { get; set; }
    }
}