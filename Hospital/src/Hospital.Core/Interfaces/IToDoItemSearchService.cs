using Ardalis.Result;
using Hospital.Core.ProjectAggregate;

namespace Hospital.Core.Interfaces;

  public interface IToDoItemSearchService
  {
      Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
      Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
  }
