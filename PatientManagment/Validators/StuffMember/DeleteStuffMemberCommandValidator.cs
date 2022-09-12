using FluentValidation;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.StuffMember
{
    public class DeleteStuffMemberCommandValidator : AbstractValidator<DeleteStuffMemberCommand>
    {
        public DeleteStuffMemberCommandValidator(IGenericRepository<Entities.StuffMember> stuffMemberRepo)
        {
            RuleFor(x => x.Id)
                .IsEntityExist(stuffMemberRepo, "StuffMember");
        }
    }
}
