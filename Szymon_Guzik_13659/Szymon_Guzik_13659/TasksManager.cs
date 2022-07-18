using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_Guzik_13659.Tasks;

namespace Szymon_Guzik_13659
{
    public class TaskEventArgs : EventArgs, ITask 
    {
        public string Name { get; set; }
    }
    class TasksManager
    {
        private List<ITask> waitingTasks = new List<ITask>();
        private List<ITask> finishedTasks = new List<ITask>();

        public event EventHandler<TaskEventArgs> TaskAdded;
        public event EventHandler<TaskEventArgs> TaskFinished;

        public void AddTask(string name, int priority)
        {
            PriorityTask newTask = new PriorityTask(name, priority);

            waitingTasks.Add(newTask);

            TaskEventArgs args = new TaskEventArgs();
            args.Name = name;
            this.OnTaskAdded(args);
        }

        public void AddTask(string name, int priority, string description)
        {
            DescribedTask newTask = new DescribedTask(name, priority, description);

            waitingTasks.Add(newTask);

            TaskEventArgs args = new TaskEventArgs();
            args.Name = name;
            this.OnTaskAdded(args);
        }

        public void FinishTask(int index)
        {
            if (index < 0 || index > waitingTasks.Count)
                return;

            finishedTasks.Add(waitingTasks[index]);
            waitingTasks.RemoveAt(index);

            TaskEventArgs args = new TaskEventArgs();
            args.Name = waitingTasks[index].Name;
            this.OnTaskFinshedd(args);
        }

        private string loopTasks(List<ITask> tasks, string prefix = "-")
        {
            string result = "";

            for (int i = 0; i < tasks.Count; i++)
            {
                result += $" {prefix} {i+1}: {{{tasks[i].ToString()}}}\n";
            }

            return result;
        }

        public override string ToString()
        {
            string result = "WAITING:\n";

            result += loopTasks(this.waitingTasks);
            result += "FINISHED:\n";
            result += loopTasks(this.finishedTasks, "+");

            return result;
        }

        private void OnTaskAdded(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> handler = TaskAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnTaskFinshedd(TaskEventArgs e)
        {
            EventHandler<TaskEventArgs> handler = TaskFinished;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
