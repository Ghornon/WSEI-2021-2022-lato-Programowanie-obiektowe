using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    /// <summary>
    ///   DB connection context
    /// </summary>
    public class AppDBContext : DbContext
    {
        /// <summary>
        /// Create Users Model
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Create Statuses Model
        /// </summary>
        public DbSet<Status> Statuses { get; set; }
        /// <summary>
        /// Create Tasks Model
        /// </summary>
        public DbSet<Task> Tasks { get; set; }
        /// <summary>
        /// Create Tags Model
        /// </summary>
        public DbSet<Tag> Tags { get; set; }
        /// <summary>
        /// Create TaggedTasks Model
        /// </summary>
        public DbSet<TaggedTask> TaggedTasks { get; set; }

        private string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDoAppDB;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
}