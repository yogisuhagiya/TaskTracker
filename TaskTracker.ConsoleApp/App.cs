// TaskTracker.ConsoleApp/App.cs
using TaskTracker.Application;

public class App
{
    private readonly ITaskService _taskService;

    public App(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task RunAsync()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Task Tracker Menu ---");
            Console.WriteLine("1. View tasks");
            Console.WriteLine("2. Add a new task");
            Console.WriteLine("3. Mark a task as complete");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    await ViewTasks();
                    break;
                case "2":
                    await AddNewTask();
                    break;
                case "3":
                    await MarkTaskComplete();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private async Task ViewTasks()
    {
        var tasks = await _taskService.ListTasks();
        if (!tasks.Any())
        {
            Console.WriteLine("No tasks to display.");
            return;
        }

        Console.WriteLine("\n--- Tasks ---");
        foreach (var task in tasks)
        {
            var status = task.IsCompleted ? "Completed" : "Pending";
            Console.WriteLine($"[{task.Id}] - {task.Name} ({status})");
        }
    }

    private async Task AddNewTask()
    {
        Console.Write("Enter task name: ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            await _taskService.AddTask(name);
            Console.WriteLine("Task added.");
        }
        else
        {
            Console.WriteLine("Task name cannot be empty.");
        }
    }

    private async Task MarkTaskComplete()
    {
        Console.Write("Enter task ID to complete: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            await _taskService.CompleteTask(id);
            Console.WriteLine("Task marked as complete.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}