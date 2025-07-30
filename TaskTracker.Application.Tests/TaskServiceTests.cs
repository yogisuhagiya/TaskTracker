

using Moq;                 
using TaskTracker.Application;
using TaskTracker.Domain;
using Xunit;

namespace TaskTracker.Application.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepo; 
        private readonly ITaskService _taskService;       

        
        public TaskServiceTests()
        {
           
            _mockRepo = new Mock<ITaskRepository>();

            
            _taskService = new TaskService(_mockRepo.Object);
        }

       
        [Fact]
        public async Task AddTask_ShouldCallRepositoryAddTaskAsync()
        {
            // Arrange
            var taskName = "Test a new task";

         
            await _taskService.AddTask(taskName);

            
            _mockRepo.Verify(repo => repo.AddTaskAsync(It.IsAny<TaskItem>()), Times.Once);
        }

    
        [Fact]
        public async Task ListTasks_ShouldReturnAllTasksFromRepository()
        {
        
            var fakeTasks = new List<TaskItem>
            {
                new TaskItem("Task 1"),
                new TaskItem("Task 2")
            };

         
            _mockRepo.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(fakeTasks);

          
            var result = await _taskService.ListTasks();

          
            Assert.Equal(2, result.Count());
            Assert.Equal("Task 1", result.First().Name);
        }

        [Fact]
        public async Task CompleteTask_ShouldCallUpdateOnRepository_WhenTaskExists()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            var fakeTask = new TaskItem("A task to complete");

      
            _mockRepo.Setup(repo => repo.GetTaskByIdAsync(taskId)).ReturnsAsync(fakeTask);

        
            await _taskService.CompleteTask(taskId);

       
            Assert.True(fakeTask.IsCompleted);
            
            _mockRepo.Verify(repo => repo.UpdateTaskAsync(fakeTask), Times.Once);
        }
    }
}
