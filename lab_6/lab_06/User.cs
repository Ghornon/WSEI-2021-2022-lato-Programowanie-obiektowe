using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_06
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        private string role;
        public string Role { get { return role; }
            set {
                if (value == "ADMIN" || value == "MODERATOR" || value == "TEACHER" || value == "STUDENT")
                    role = value;
            }
        } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        private int[] marks;
        public int[] Marks { get { return marks; }
            set {
                if (this.Role != "STUDENT")
                    marks = null;
                else
                    marks = value;
            }
        } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }

        public User() { }

        public User(string Name, string Role, int Age, int[] Marks, DateTime? CreatedAt, DateTime? RemovedAt)
        {
            this.Name = Name;
            this.Role = Role;
            this.Age = Age;
            this.Marks = Marks;
            this.CreatedAt = CreatedAt;
            this.RemovedAt = RemovedAt;
        }

        public override string ToString()
        {
            string result = $"{Name}, Role: {Role}, Marks: {(Marks != null && Marks.Length > 0 ? string.Join(", ", Marks) : "null")}, ";
                result += $"CreatedAt: {(CreatedAt != null ? CreatedAt.ToString() : "null")}, ";
                result += $"RemovedAt: {(RemovedAt != null ? RemovedAt.ToString() : "null")}";

            return result;
        }
    }
}
