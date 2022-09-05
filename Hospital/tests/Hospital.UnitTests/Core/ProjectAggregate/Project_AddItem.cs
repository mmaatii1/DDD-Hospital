using Hospital.Core.ProjectAggregate;
using Xunit;

namespace Hospital.UnitTests.Core.ProjectAggregate
{
    public class Project_AddItem
    {
        private Calendar _testProject = new Calendar("some name", PriorityStatus.Backlog);

        [Fact]
        public void AddsItemToItems()
        {
            var _testItem = new ToDoItem
            {
                Title = "title",
                Description = "description"
            };

            _testProject.AddItem(_testItem);

            Assert.Contains(_testItem, _testProject.Items);
        }

        [Fact]
        public void ThrowsExceptionGivenNullItem()
        {
#nullable disable
            Action action = () => _testProject.AddItem(null);
#nullable enable

            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("newItem", ex.ParamName);
        }
    }
}