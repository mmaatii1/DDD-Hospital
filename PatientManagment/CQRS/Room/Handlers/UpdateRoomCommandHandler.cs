using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.CQRS.Room.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Room.Handlers
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomResponse>
    {
        private readonly IGenericRepository<Entities.Room> _roomRepository;
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateRoomCommandHandler(IGenericRepository<Entities.Room> repo, IMapper mapper, IGenericRepository<Entities.Department> departmentRepo)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepo;
            _roomRepository = repo;
        }

        public async Task<RoomResponse> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
        {
            var roomToUpdate = _mapper.Map<Entities.Room>(command);
            var department = await _departmentRepository.GetByIdAsync(command.DepartmentId);
            roomToUpdate.Department = department;
            var updatedRoom = await _roomRepository.UpdateAsync(roomToUpdate);
            return _mapper.Map<RoomResponse>(updatedRoom);
        }
    }
}
