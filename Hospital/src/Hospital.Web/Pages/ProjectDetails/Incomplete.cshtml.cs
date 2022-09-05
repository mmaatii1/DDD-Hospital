using Hospital.Core.ProjectAggregate;
using Hospital.Core.ProjectAggregate.Specifications;
using Hospital.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hospital.Web.Pages.ProjectDetails
{
    public class IncompleteModel : PageModel
    {
        private readonly IRepository<Calendar> _repository;

        [BindProperty(SupportsGet = true)]
        public int ProjectId { get; set; }

        public List<ToDoItem>? ToDoItems { get; set; }

        public IncompleteModel(IRepository<Calendar> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _repository.FirstOrDefaultAsync(projectSpec);
            if (project == null)
            {
                return;
            }

            var spec = new IncompleteItemsSpec();

            ToDoItems = spec.Evaluate(project.Items).ToList();
        }
    }
}