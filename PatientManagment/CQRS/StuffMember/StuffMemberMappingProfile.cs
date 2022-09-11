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
            CreateMap<Entities.StuffMember, StuffMemberResponse>();
        }
    }
}
