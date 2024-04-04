using System.ComponentModel;


internal class Program
{
    private static void Main(string[] args)
    {
        //Main will go here
        ToDoListManager obj = new ToDoListManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display Tasks");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Clear All Tasks");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    obj.AddTask();
                    break;
                case "2":
                    obj.DisplayTasks();
                    break;
                case "3":
                    obj.DeleteTask();
                    break;
                case "4":
                    obj.ClearAllTask();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        }
    }
}

class Task
{
    public string Description { get; }
    public string Time { get; }

    public Task(string description, string time)
    {
        Description = description;
        Time = time;
    }
}







class ToDoListManager //This is a class that will hold all methods we need
{
    //create encapsulation variable
    private Task[] tasks = new Task[100];
    private int taskCount = 0;
    
    
    //Add method to add task

    public void AddTask()
    {
        if(taskCount < tasks.Length)
        {
            Console.WriteLine("Please Enter task description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Please Enter time: ");
            string time = Console.ReadLine();

            tasks[taskCount] = new Task(description, time);
            taskCount++;
        }
        else
        {
            Console.WriteLine("Task list is Full");
        }
    }

    //method to delete

    public void DeleteTask()
    {
        Console.WriteLine("Please task number you want to delete");
        if(int.TryParse(Console.ReadLine(),out int taskNumber) && taskNumber >= 1 & taskNumber <= taskCount)
        {
            //shift tasks in the array to remove the deleted task
            for (int i = taskNumber - 1; i < taskCount - 1; i++)
            {
                tasks[i] = tasks[i + 1];
            }
            tasks[taskCount - 1] = null; // clear last element
            taskCount--;
            Console.WriteLine("Task deleted successfully");
        }
        else
        {
            Console.WriteLine("Invalid task number . Please add a valid task number");
        }
    }

    //method to clear task

    public void ClearAllTask()
    {
        Array.Clear(tasks, 0, tasks.Length);
        taskCount = 0;
        Console.WriteLine("All Task were cleared");
    }

    //display method
    public void DisplayTasks()
    {
        if (taskCount == 0)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        Console.WriteLine("Tasks:");
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine("Task Number: " + (i + 1) + "\n" + "Task Description: " + tasks[i].Description + "\n" + "Time: " + tasks[i].Time);
        }
    }

    }

