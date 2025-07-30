

using TaskTracker.Domain; 
using Xunit;            

namespace TaskTracker.Domain.Tests
{
    public class TaskItemTests
    {
        
        [Fact]
        public void NewTask_ShouldBePendingAndHaveCorrectName()
        {
        
            var taskName = "My first test task";
            var task = new TaskItem(taskName);

     

      
            Assert.Equal(taskName, task.Name); 
            Assert.False(task.IsCompleted);     
            Assert.NotEqual(Guid.Empty, task.Id); 
        }

       
        [Fact]
        public void MarkComplete_ShouldSetIsCompletedToTrue()
        {
            
            var task = new TaskItem("A task to be completed");

          
            task.MarkComplete();

            
            Assert.True(task.IsCompleted); 
        }

      
        [Fact]
        public void NewTask_WithEmptyName_ShouldThrowArgumentException()
        {
       
            Assert.Throws<ArgumentException>(() => new TaskItem(""));
        }
    }
}
