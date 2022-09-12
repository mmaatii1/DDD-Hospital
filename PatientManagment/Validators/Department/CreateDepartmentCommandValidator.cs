using FluentValidation;
using PatientManagement.Core.CQRS.Department.Commands;

namespace PatientManagement.Core.Validators.Department
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
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
