using System;
using System.Collections.Generic;

class ToDoListApp
{
    static void Main(string[] args)
    {
        ToDoListManager listManager = new ToDoListManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display Tasks");
            Console.WriteLine("3. Clear All Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    listManager.AddTask();
                    break;
                case "2":
                    listManager.DisplayTasks();
                    break;
                case "3":
                    listManager.ClearAllTasks();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class ToDoListManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask()
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();
        tasks.Add(new Task(description));
    }

    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        Console.WriteLine("Tasks:");
        int count = 1;
        foreach (Task task in tasks)
        {
            Console.WriteLine("For Task number: " + count + "\n" + "Your Task Description is: " + task.Description);
            count++;
        }
    }

    public void ClearAllTasks()
    {
        tasks.Clear();
        Console.WriteLine("All tasks cleared.");
    }
}

class Task
{
    public string Description { get; }

    public Task(string description)
    {
        Description = description;
    }
}
