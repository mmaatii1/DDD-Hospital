using AutoMapper;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Requests;
using PatientManagement.Core.CQRS.StuffMember.Responses;

namespace PatientManagement.Core.CQRS.StuffMember
{
    public class StuffMemberMappingProfile : Profile
    {
        public StuffMemberMappingProfile()
        {
            CreateMap<CreateStuffMemberCommand, Entities.StuffMember>();
            CreateMap<Entities.StuffMember, StuffMemberResponse>();
            CreateMap<CreateStuffMemberRequest, CreateStuffMemberCommand>();
            //update
            CreateMap<UpdateStuffMemberCommand, Entities.StuffMember>();
            CreateMap<UpdateStuffMemberCommand, StuffMemberResponse>();
            CreateMap<UpdateStuffMemberRequest, UpdateStuffMemberCommand>();
            //delete
            CreateMap<Entities.StuffMember, StuffMemberResponse>();
            //get
            CreateMap<Entities.Department, StuffMemberResponse>()
                .ForMember(x => x.DepartmentDescription, x => x.MapFrom(c => c.Description))
                .ForMember(x => x.DepartmentId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.DepartmentName, x => x.MapFrom(c => c.Name));
            CreateMap<Entities.TypeOfStuffMember, StuffMemberResponse>()
                .ForMember(x => x.TypeOfStuffMemberDescription, x => x.MapFrom(c => c.Description))
                .ForMember(x => x.TypeOfStuffMemberId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.TypeOfStuffMemberName, x => x.MapFrom(c => c.Name));
            CreateMap<Entities.StuffMember, StuffMemberResponse>();
        }
    }
}
