using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    class appDBContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public string ConnectionString = @"Server=(localdb)\\MSSQLLocalDB;Database=SomeDbName;Trusted_Connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
    
}
