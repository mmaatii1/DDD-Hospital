using FluentValidation;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.TypeOfStuffMember
{
    public class DeleteTypeOfStuffMemberCommandValidator : AbstractValidator<DeleteTypeOfStuffMemberCommand>
    {
        public DeleteTypeOfStuffMemberCommandValidator(IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepo)
        {
            RuleFor(x => x.Id)
                .IsEntityExist(typeOfStuffMemberRepo, "TypeOfStuffMember");
        }
    }
}
