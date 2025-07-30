// TaskTracker.Domain/TaskItem.cs
namespace TaskTracker.Domain
{
    public class TaskItem
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedOn { get; }

        public TaskItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Task name cannot be empty.", nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name;
            IsCompleted = false;
            CreatedOn = DateTime.UtcNow;
        }

        public void MarkComplete()
        {
            IsCompleted = true;
        }
    }
}