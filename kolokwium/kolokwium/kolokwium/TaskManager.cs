using Szymon_Guzik_13659.Tasks;
using System;
using System.Collections.Generic;

namespace Szymon_Guzik_13659
{
    class TasksManager
    {
        public List<ITask> waitingTasks = new List<ITask>();
        public List<ITask> finishedTasks = new List<ITask>();

        public void AddTask(string name, int priority)
        {
            waitingTasks.Add(new PriorityTask(name, priority));
        }

        public void AddTask(string name, int priority, string description)
        {
            waitingTasks.Add(new DescribedTask(name, priority, description));
        }

        public void FinishTask(int index)
        {
            if (index < waitingTasks.Count)
            {
                finishedTasks.Add(waitingTasks[index]);
                waitingTasks.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            string waitingTasksString = "";
            waitingTasks.Sort();
            for (int i = 0; i < waitingTasks.Count; i++)
            {
                waitingTasksString += " - " + i + ": " + waitingTasks[i].ToString() + "\n";
            }
            finishedTasks.Sort();
            string finishedTasksString = "";
            for (int i = 0; i < finishedTasks.Count; i++)
            {
                finishedTasksString += " + " + i + ": " + finishedTasks[i].ToString() + "\n";
            }
            return "WAITING:\n" + waitingTasksString + "FINISHED:\n" + finishedTasksString;
        }
    }
}
