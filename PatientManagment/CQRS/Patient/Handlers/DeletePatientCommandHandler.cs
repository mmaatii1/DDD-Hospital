using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Patient.Handlers
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, PatientResponse>
    {
        private readonly IGenericRepository<Entities.Patient> _patientRepository;
        private readonly IMapper _mapper;

        public DeletePatientCommandHandler(IGenericRepository<Entities.Patient> repo, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repo;
        }

        public async Task<PatientResponse> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            var patientToDelete = await _patientRepository.DeleteAsync(command.Id);
            return _mapper.Map<PatientResponse>(patientToDelete);
        }
    }
}
