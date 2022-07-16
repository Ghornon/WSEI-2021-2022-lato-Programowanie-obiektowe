using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Szymon_Guzik_13659.TasksManager;

namespace Szymon_Guzik_13659
{
    class Program
    {
        static void Main(string[] args)
        {
            TasksManager tasksManager = new TasksManager();

            tasksManager.AddTask("Task 3", 1);
            tasksManager.AddTask("Task 1", 1);
            tasksManager.AddTask("Task 2", 1);
            tasksManager.AddTask("Task 2", 2, "Description 2");
            tasksManager.AddTask("Task 1", 2, "Description 1");

            Console.WriteLine(tasksManager);

            Console.WriteLine("-----------------------------------");

            tasksManager.FinishTask(1);
            tasksManager.FinishTask(0);

            Console.WriteLine(tasksManager);
        }
    }
}
