using FluentValidation;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Department
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator(IGenericRepository<Entities.Department> departmentRepo)
        {
            RuleFor(x => x.Id)
                .IsEntityExist(departmentRepo, "Department");
        }
    }
}
