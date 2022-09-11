using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Queries;
using PatientManagement.Core.CQRS.Patient.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Patient.Handlers
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery,IEnumerable<PatientResponse>>
    {
        private readonly IGenericRepository<Entities.Patient> _patientRepository;
        private readonly IMapper _mapper;
        public GetAllPatientsQueryHandler(IGenericRepository<Entities.Patient> repo, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repo;
        }

        public async Task<IEnumerable<PatientResponse>> Handle(GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientResponse>>(patients);
        }
    }
}
