using FluentValidation;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.TypeOfStuffMember
{
    public class UpdateTypeOfStuffMemberCommandValidator : AbstractValidator<UpdateTypeOfStuffMemberCommand>
    {
        public UpdateTypeOfStuffMemberCommandValidator(IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepo)
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
