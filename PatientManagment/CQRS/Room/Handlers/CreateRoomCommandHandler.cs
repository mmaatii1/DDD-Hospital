using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.CQRS.Room.Responses;
using PatientManagement.Core.Interfaces;


namespace PatientManagement.Core.CQRS.Room.Handlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResponse>
    {
        private readonly IGenericRepository<Entities.Room> _roomRepository;
        private readonly IGenericRepository<Entities.Department> _departmentRepo;
        private readonly IMapper _mapper;

        public CreateRoomCommandHandler(IGenericRepository<Entities.Room> repo, IMapper mapper, IGenericRepository<Entities.Department> departmentRepo)
        {
            _mapper = mapper;
            _roomRepository = repo;
            _departmentRepo = departmentRepo;
        }

        public async Task<RoomResponse> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
        {
            var department = await _departmentRepo.GetByIdAsync(command.DepartmentId);
            var room = _mapper.Map<Entities.Room>(command);
            room.Department = department;
            var createdEntity = await _roomRepository.AddAsync(room);
            return _mapper.Map<RoomResponse>(createdEntity);
        }
    }
}
