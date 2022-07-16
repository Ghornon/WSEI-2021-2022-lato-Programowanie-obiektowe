using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szymon_Guzik_13659.Tasks
{
    public class PriorityTask: ITask
    {
        public string Name { get; }
        public int Priority { get; }

        public PriorityTask()
        {

        }

        public PriorityTask(string name, int priority)
        {
            this.Name = name;
            this.Priority = priority;

        }
        public PriorityTask(PriorityTask otherTask)
        {
            this.Name = otherTask.Name;
            this.Priority = otherTask.Priority;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}; Priority: {this.Priority};";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType())) return false;

            PriorityTask priorityTask = obj as PriorityTask;

            if (priorityTask == null) return false;

            return (this.Name == priorityTask.Name) && (this.Priority == priorityTask.Priority);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Priority.GetHashCode();
        }
    }
}
