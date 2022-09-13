using FluentValidation;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Room
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator(IGenericRepository<Entities.Room> roomRepo, IGenericRepository<Entities.Department> departmentRepo)
        {
            RuleFor(x => x.RoomNumber)
                .GreaterThan(0);
            RuleFor(x => x.Id)
                .IsEntityExist(roomRepo, "Room");
            RuleFor(x => x.DepartmentId)
                .IsEntityExist(departmentRepo, "Department");
        }
    }
}

