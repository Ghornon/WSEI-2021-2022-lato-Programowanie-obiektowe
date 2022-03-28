using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public enum TaskStatus
    {
        Waiting,
        Progress,
        Done,
        Rejected
    }

    public class Task : IEquatable<Task>
    {
        private string name;
        private TaskStatus status;

        public string Name { get => name; set => name = value; }
        public TaskStatus Status { get => status; set => status = value; }

        public Task(string name, TaskStatus status)
        {
            Name = name;
            Status = status;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Task otherTask = obj as Task;
            if (otherTask == null)
                return false;
            else
                return Equals(otherTask);
        }
        public bool Equals(Task other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Status == other.Status)
                return true;
            else
                return false;
        }
        public override int GetHashCode() => HashCode.Combine(Name, Status);

        public override string ToString() => $"{Name} [{Status}]";
    }
}
