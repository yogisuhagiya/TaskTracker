// TaskTracker.Domain.Tests/TaskItemTests.cs

using TaskTracker.Domain; // Gives us access to the TaskItem class
using Xunit;             // Gives us access to [Fact] and Assert

namespace TaskTracker.Domain.Tests
{
    public class TaskItemTests
    {
        // Test 1: Checks if a new TaskItem is created with the correct default values.
        [Fact]
        public void NewTask_ShouldBePendingAndHaveCorrectName()
        {
            // Arrange: Set up the test by creating a new task.
            var taskName = "My first test task";
            var task = new TaskItem(taskName);

            // Act: The action of creating the task happened in the "Arrange" step.

            // Assert: Verify that the outcome is correct.
            Assert.Equal(taskName, task.Name); // The name should be what we provided.
            Assert.False(task.IsCompleted);      // The task should not be completed yet.
            Assert.NotEqual(Guid.Empty, task.Id); // The ID should be a valid GUID.
        }

        // Test 2: Checks if the MarkComplete() method correctly changes the IsCompleted property.
        [Fact]
        public void MarkComplete_ShouldSetIsCompletedToTrue()
        {
            // Arrange: Create a task.
            var task = new TaskItem("A task to be completed");

            // Act: Perform the specific action we want to test.
            task.MarkComplete();

            // Assert: Check if the property was changed correctly.
            Assert.True(task.IsCompleted); // The task should now be marked as complete.
        }

        // Test 3: Checks that our business rule (no empty names) is enforced.
        [Fact]
        public void NewTask_WithEmptyName_ShouldThrowArgumentException()
        {
            // Arrange, Act, and Assert all in one line:
            // We expect an ArgumentException to be thrown when we try to create a TaskItem with an empty string.
            Assert.Throws<ArgumentException>(() => new TaskItem(""));
        }
    }
}