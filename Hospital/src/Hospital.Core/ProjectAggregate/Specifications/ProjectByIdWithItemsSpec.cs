using Ardalis.Specification;
using Hospital.Core.ProjectAggregate;

namespace Hospital.Core.ProjectAggregate.Specifications
{
    public class ProjectByIdWithItemsSpec : Specification<Calendar>, ISingleResultSpecification
    {
        public ProjectByIdWithItemsSpec(int projectId)
        {
            Query
                .Where(project => project.Id == projectId)
                .Include(project => project.Items);
        }
    }
}