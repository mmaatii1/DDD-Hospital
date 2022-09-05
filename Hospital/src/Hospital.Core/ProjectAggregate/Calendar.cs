using Ardalis.GuardClauses;
using Hospital.Core.ProjectAggregate.Events;
using Hospital.SharedKernel;
using Hospital.SharedKernel.Interfaces;

namespace Hospital.Core.ProjectAggregate
{
    public class Calendar : EntityBase<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }

        private List<ToDoItem> _items = new List<ToDoItem>();
        public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
        public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        public PriorityStatus Priority { get; }

        public Calendar(string name, PriorityStatus priority)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Priority = priority;
        }

        public void AddItem(ToDoItem newItem)
        {
            Guard.Against.Null(newItem, nameof(newItem));
            _items.Add(newItem);

            var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
            base.RegisterDomainEvent(newItemAddedEvent);
        }

        public void UpdateName(string newName)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
    }
}
