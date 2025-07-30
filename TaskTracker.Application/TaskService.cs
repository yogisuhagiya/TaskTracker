// TaskTracker.Application/TaskService.cs
using TaskTracker.Domain;

namespace TaskTracker.Application
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItem> AddTask(string name)
        {
            var taskItem = new TaskItem(name);
            await _taskRepository.AddTaskAsync(taskItem);
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> ListTasks()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task CompleteTask(Guid id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task != null)
            {
                task.MarkComplete();
                await _taskRepository.UpdateTaskAsync(task);
            }
        }
    }
}