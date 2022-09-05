using Hospital.SharedKernel;

namespace Hospital.Core.ProjectAggregate.Events
{
    public class NewItemAddedEvent : DomainEventBase
    {
        public ToDoItem NewItem { get; set; }
        public Calendar Project { get; set; }

        public NewItemAddedEvent(Calendar project,
            ToDoItem newItem)
        {
            Project = project;
            NewItem = newItem;
        }
    }
}