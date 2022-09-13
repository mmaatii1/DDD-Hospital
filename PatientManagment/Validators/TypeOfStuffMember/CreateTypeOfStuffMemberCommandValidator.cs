
using FluentValidation;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;

namespace PatientManagement.Core.Validators.TypeOfStuffMember
{
    public class CreateTypeOfStuffMemberCommandValidator : AbstractValidator<CreateTypeOfStuffMemberCommand>
    {
        public CreateTypeOfStuffMemberCommandValidator()
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
