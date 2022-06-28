using ToDoApp.Models;

namespace ToDoApp.Helpers
{
    /// <summary>
    ///   Cross window authentication helper
    /// </summary>
    public class AuthHelper
    {
        public User User { get; }
        public bool IsAuthenticated { get; } = false;

        /// <summary>Initializes a new instance of the <see cref="AuthHelper" /> class.</summary>
        /// <param name="user">The user.</param>
        public AuthHelper(User user)
        {
            this.User = user;
            this.IsAuthenticated = true;
        }
    }
}