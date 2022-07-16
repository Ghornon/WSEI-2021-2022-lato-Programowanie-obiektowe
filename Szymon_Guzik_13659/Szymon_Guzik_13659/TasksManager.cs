using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymon_Guzik_13659.Tasks;

namespace Szymon_Guzik_13659
{
    class TasksManager
    {
        private List<ITask> waitingTasks = new List<ITask>();
        private List<ITask> finishedTasks = new List<ITask>();

        public void AddTask(string name, int priority)
        {
            PriorityTask newTask = new PriorityTask(name, priority);

            waitingTasks.Add(newTask);
        }

        public void AddTask(string name, int priority, string description)
        {
            DescribedTask newTask = new DescribedTask(name, priority, description);

            waitingTasks.Add(newTask);
        }

        public void FinishTask(int index)
        {
            finishedTasks.Add(waitingTasks[index]);
            waitingTasks.RemoveAt(index);
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
    }
}
