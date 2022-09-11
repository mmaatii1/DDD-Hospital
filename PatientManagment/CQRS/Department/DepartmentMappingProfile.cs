using AutoMapper;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.CQRS.Department.Requests;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            //create
            CreateMap<CreateDepartmentCommand, Entities.Department>();
            CreateMap<Entities.Department, DepartmentResponse>();
            CreateMap<CreateDepartmentRequest, CreateDepartmentCommand>();
            //update
            CreateMap<UpdateDepartmentCommand, Entities.Department>();
            CreateMap<UpdateDepartmentCommand, DepartmentResponse>();
            CreateMap<UpdateDepartmentRequest, UpdateDepartmentCommand>();
            //delete
            CreateMap<Entities.Department, DepartmentResponse>();
            //get
            CreateMap<Entities.Department, DepartmentResponse>();
        }
    }
}
