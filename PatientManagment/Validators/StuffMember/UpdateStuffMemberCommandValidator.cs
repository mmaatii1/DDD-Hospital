using FluentValidation;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.StuffMember
{
    public class UpdateStuffMemberCommandValidator : AbstractValidator<UpdateStuffMemberCommand>
    {
        public UpdateStuffMemberCommandValidator(IGenericRepository<Entities.Department> departmentRepo, IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepo,IGenericRepository<Entities.StuffMember> stuffMemberRepo)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
