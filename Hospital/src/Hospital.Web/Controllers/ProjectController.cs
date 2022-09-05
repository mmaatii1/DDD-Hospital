using Hospital.Core.ProjectAggregate;
using Hospital.Core.ProjectAggregate.Specifications;
using Hospital.SharedKernel.Interfaces;
using Hospital.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Calendar> _projectRepository;

        public ProjectController(IRepository<Calendar> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.FirstOrDefaultAsync(spec);
            if (project == null)
            {
                return NotFound();
            }

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}