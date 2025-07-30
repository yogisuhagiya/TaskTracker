// TaskTracker.ConsoleApp/Program.cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskTracker.Application;
using TaskTracker.Infrastructure;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Registering our services for DI
                services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
                services.AddTransient<ITaskService, TaskService>();
                services.AddTransient<App>(); // The main application class
            })
            .Build();

        // Get the App service and run it
        var app = host.Services.GetRequiredService<App>();
        await app.RunAsync();
    }
}