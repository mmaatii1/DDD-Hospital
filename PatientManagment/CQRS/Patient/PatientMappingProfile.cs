
using AutoMapper;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Requests;
using PatientManagement.Core.CQRS.Patient.Responses;

namespace PatientManagement.Core.CQRS.Patient
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<CreatePatientCommand, Entities.Patient>();
            CreateMap<Entities.Patient, PatientResponse>();
            CreateMap<CreatePatientRequest, CreatePatientCommand>().ReverseMap();
        }
    }
}
