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

            Console.WriteLine("-----------------------------------");


            TasksManager tasksManager2 = new TasksManager();

            tasksManager2.TaskAdded += (object sender, TaskEventArgs e) =>
            {
                Console.WriteLine("Task added: " + e.Name);
            };

            tasksManager2.TaskFinished += (object sender, TaskEventArgs e) =>
            {
                Console.WriteLine("Task finshed: " + e.Name);
            };

            tasksManager2.AddTask("Task 3", 1);
            tasksManager2.AddTask("Task 1", 1);
            tasksManager2.AddTask("Task 2", 1);
            tasksManager2.AddTask("Task 4", 1);
            tasksManager2.AddTask("Task 5", 1);
            tasksManager2.AddTask("Task 2", 2, "Description 2");
            tasksManager2.AddTask("Task 1", 2, "Description 1");

            tasksManager2.FinishTask(0);
            tasksManager2.FinishTask(1);
        }
    }
}