using ToDoApp.Models;

namespace ToDoApp.Helpers
{
    public class AuthHelper
    {
        public User User { get; }
        public bool IsAuthenticated { get; } = false;

        public AuthHelper(User user)
        {
            this.User = user;
            this.IsAuthenticated = true;
        }
    }
}