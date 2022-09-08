using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.CQRS.Room.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Room.Handlers
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, RoomResponse>
    {
        private readonly IGenericRepository<Entities.Room> _roomRepository;
        private readonly IMapper _mapper;

        public DeleteRoomCommandHandler(IGenericRepository<Entities.Room> repo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepository = repo;
        }

        public async Task<RoomResponse> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
        {
            var roomToDelete = await _roomRepository.DeleteAsync(command.Id);
            return _mapper.Map<RoomResponse>(roomToDelete);
        }
    }
}
