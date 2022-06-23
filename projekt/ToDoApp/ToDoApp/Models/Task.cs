using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        
    }
}
