using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Room.Responses;
using PatientManagement.Core.Interfaces;
using PatientManagement.Core.CQRS.Room.Queries;

namespace PatientManagement.Core.CQRS.Room.Handlers
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomResponse>>
    {
        private readonly IGenericRepository<Entities.Room> _roomRepository;
        private readonly IMapper _mapper;
        public GetAllRoomsQueryHandler(IGenericRepository<Entities.Room> repo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepository = repo;
        }

        public async Task<IEnumerable<RoomResponse>> Handle(GetAllRoomsQuery request,
            CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoomResponse>>(rooms);
        }
    }
}
