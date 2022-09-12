using FluentValidation;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Room
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator(IGenericRepository<Entities.Department> departmentRepo)
        {
            RuleFor(x => x.RoomNumber)
                .GreaterThan(0);
            RuleFor(x => x.DepartmentId)
                .IsEntityExist(departmentRepo,"Department");
        }
    }
}
