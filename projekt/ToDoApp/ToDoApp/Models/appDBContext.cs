using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    /// <summary>
    ///   DB connection context
    /// </summary>
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaggedTask> TaggedTasks { get; set; }

        public string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDoAppDB;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
}