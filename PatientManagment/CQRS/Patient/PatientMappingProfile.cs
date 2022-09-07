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
            //create
            CreateMap<CreatePatientCommand, Entities.Patient>();
            CreateMap<Entities.Patient, PatientResponse>();
            CreateMap<CreatePatientRequest, CreatePatientCommand>();
            //update
            CreateMap<UpdatePatientCommand, Entities.Patient>();
            CreateMap<UpdatePatientCommand, PatientResponse>();
            CreateMap<UpdatePatientRequest, UpdatePatientCommand>();
            //delete
            CreateMap<Entities.Patient, PatientResponse>();
            //get
            CreateMap<Entities.Patient, PatientResponse>();

        }
    }
}
