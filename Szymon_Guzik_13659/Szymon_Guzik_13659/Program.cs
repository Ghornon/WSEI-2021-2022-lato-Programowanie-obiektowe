using System;
using Szymon_Guzik_13659;

namespace ConsoleApp___exam___v7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TasksManager tasksManager = new TasksManager();

            tasksManager.AddTask("Task 3", 1);
            tasksManager.AddTask("Task 1", 1);
            tasksManager.AddTask("Task 2", 1);
            tasksManager.AddTask("Task 4", 1);
            tasksManager.AddTask("Task 5", 1);
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