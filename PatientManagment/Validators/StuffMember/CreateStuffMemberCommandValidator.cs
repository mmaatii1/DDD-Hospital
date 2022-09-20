
using FluentValidation;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.StuffMember
{
    public class CreateStuffMemberCommandValidator : AbstractValidator<CreateStuffMemberCommand>
    {
        public CreateStuffMemberCommandValidator(IGenericRepository<Entities.Department> departmentRepo,IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepo)
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
