using FluentValidation;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Department
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator(IGenericRepository<Entities.Department> departmentRepo)
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
            
        }
    }
}
