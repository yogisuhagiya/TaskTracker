// TaskTracker.Infrastructure/InMemoryTaskRepository.cs
using TaskTracker.Application;
using TaskTracker.Domain;

namespace TaskTracker.Infrastructure
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();

        public Task AddTaskAsync(TaskItem task)
        {
            _tasks.Add(task);
            return Task.CompletedTask;
        }

        public Task<TaskItem?> GetTaskByIdAsync(Guid id)
        {
            return Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
        }

        public Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return Task.FromResult<IEnumerable<TaskItem>>(_tasks);
        }

        public Task UpdateTaskAsync(TaskItem task)
        {
            // In a real database, this would perform an update.
            // For an in-memory list, the object is already updated.
            return Task.CompletedTask;
        }
    }
}