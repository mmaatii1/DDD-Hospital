using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Room.Queries;
using PatientManagement.Core.CQRS.Room.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Room.Handlers
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomResponse>
    {
        private readonly IGenericRepository<Entities.Room> _roomRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Entities.Department> _departmentGenericRepository;
        public GetRoomByIdQueryHandler(IGenericRepository<Entities.Room> repo, IMapper mapper, IGenericRepository<Entities.Department> departmentGenericRepository)
        {
            _mapper = mapper;
            _roomRepository = repo;
            _departmentGenericRepository = departmentGenericRepository;
        }

        public async Task<RoomResponse> Handle(GetRoomByIdQuery request,
            CancellationToken cancellationToken)
        {
            var rooms = _roomRepository
                .GetWithEntity(x => x.Department)
                .FirstOrDefault(c => c.Id == request.Id);

            return _mapper.Map<RoomResponse>(rooms);
        }
    }
}
