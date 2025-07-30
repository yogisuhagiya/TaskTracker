// TaskTracker.Application.Tests/TaskServiceTests.cs

using Moq;                 // Gives us access to the Mock object for creating fakes.
using TaskTracker.Application;
using TaskTracker.Domain;
using Xunit;

namespace TaskTracker.Application.Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepo; // This is our fake (mocked) repository.
        private readonly ITaskService _taskService;       // This is the real service we are testing.

        // This constructor runs before every single test in this class.
        public TaskServiceTests()
        {
            // 1. Create a new fake repository for each test to ensure they are isolated.
            _mockRepo = new Mock<ITaskRepository>();

            // 2. Create an instance of our real TaskService, but inject the FAKE repository.
            _taskService = new TaskService(_mockRepo.Object);
        }

        // Test 1: Does the AddTask method correctly call the repository to save the new task?
        [Fact]
        public async Task AddTask_ShouldCallRepositoryAddTaskAsync()
        {
            // Arrange
            var taskName = "Test a new task";

            // Act: Call the method we are testing on our service.
            await _taskService.AddTask(taskName);

            // Assert: We VERIFY that the AddTaskAsync method on our FAKE repository
            // was called exactly one time with any TaskItem object.
            _mockRepo.Verify(repo => repo.AddTaskAsync(It.IsAny<TaskItem>()), Times.Once);
        }

        // Test 2: Does the ListTasks method correctly return the data it gets from the repository?
        [Fact]
        public async Task ListTasks_ShouldReturnAllTasksFromRepository()
        {
            // Arrange: Create a fake list of tasks that our fake repository will return.
            var fakeTasks = new List<TaskItem>
            {
                new TaskItem("Task 1"),
                new TaskItem("Task 2")
            };

            // Setup the mock: Tell our fake repository what to do.
            // "When the GetAllTasksAsync method is called, return our fake list of tasks."
            _mockRepo.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(fakeTasks);

            // Act: Call the method on the service. It should ask the fake repository for data.
            var result = await _taskService.ListTasks();

            // Assert: Check that the result from the service is the same fake list we created.
            Assert.Equal(2, result.Count());
            Assert.Equal("Task 1", result.First().Name);
        }

        // Test 3: Does the CompleteTask method find the right task and tell the repository to update it?
        [Fact]
        public async Task CompleteTask_ShouldCallUpdateOnRepository_WhenTaskExists()
        {
            // Arrange
            var taskId = Guid.NewGuid();
            var fakeTask = new TaskItem("A task to complete");

            // Setup the mock: "When GetTaskByIdAsync is called with this specific ID, return our fakeTask."
            _mockRepo.Setup(repo => repo.GetTaskByIdAsync(taskId)).ReturnsAsync(fakeTask);

            // Act: Call the method on the service.
            await _taskService.CompleteTask(taskId);

            // Assert
            // 1. First, check that the task object itself was marked as complete.
            Assert.True(fakeTask.IsCompleted);
            // 2. Second, VERIFY that the service told our fake repository to save the updated task.
            _mockRepo.Verify(repo => repo.UpdateTaskAsync(fakeTask), Times.Once);
        }
    }
}