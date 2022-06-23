using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    class AppDBContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDoAppDB;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
    
}
