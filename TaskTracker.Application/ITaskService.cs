// TaskTracker.Application/ITaskService.cs
using TaskTracker.Domain;

namespace TaskTracker.Application
{
    public interface ITaskService
    {
        Task<TaskItem> AddTask(string name);
        Task<IEnumerable<TaskItem>> ListTasks();
        Task CompleteTask(Guid id);
    }
}