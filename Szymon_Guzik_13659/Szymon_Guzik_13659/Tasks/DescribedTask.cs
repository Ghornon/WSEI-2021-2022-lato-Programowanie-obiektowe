using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szymon_Guzik_13659.Tasks
{
    public class DescribedTask: PriorityTask
    {
        public string Description { get; }

        public DescribedTask()
        {

        }
        public DescribedTask(string name, int priority, string description) : base(name, priority)
        {
            this.Description = description;
        }

        public DescribedTask(DescribedTask otherDescribedTask) : base(otherDescribedTask.Name, otherDescribedTask.Priority)
        {
            this.Description = otherDescribedTask.Description;
        }

        public override string ToString()
        {
            return base.ToString() + $" Description: {this.Description}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;

            DescribedTask describedTask = obj as DescribedTask;

            if (describedTask == null) return false;

            return (this.Name == describedTask.Name) && (this.Priority == describedTask.Priority) && (this.Description == describedTask.Description);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Priority.GetHashCode() + this.Description.GetHashCode();
        }
    }
}
