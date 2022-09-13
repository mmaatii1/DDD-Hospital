using FluentValidation;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Room
{
    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator(IGenericRepository<Entities.Room> roomRepo)
        {
            RuleFor(x => x.Id)
                .IsEntityExist(roomRepo, "Room");
        }
    }
}
