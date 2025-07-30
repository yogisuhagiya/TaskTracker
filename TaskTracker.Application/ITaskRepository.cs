// TaskTracker.Application/ITaskRepository.cs
using TaskTracker.Domain;

namespace TaskTracker.Application
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(TaskItem task);
        Task<TaskItem?> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task UpdateTaskAsync(TaskItem task);
    }
}