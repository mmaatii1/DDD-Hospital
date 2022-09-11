using AutoMapper;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Requests;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember
{
    public class TypeOfStuffMemberMappingProfile : Profile
    {
        public TypeOfStuffMemberMappingProfile()
        {
            CreateMap<CreateTypeOfStuffMemberCommand, Entities.TypeOfStuffMember>();
            CreateMap<Entities.TypeOfStuffMember, TypeOfStuffMemberResponse>();
            CreateMap<CreateTypeOfStuffMemberRequest, CreateTypeOfStuffMemberCommand>();
            //update
            CreateMap<UpdateTypeOfStuffMemberCommand, Entities.TypeOfStuffMember>();
            CreateMap<UpdateTypeOfStuffMemberCommand, TypeOfStuffMemberResponse>();
            CreateMap<UpdateTypeOfStuffMemberRequest, UpdateTypeOfStuffMemberCommand>();
            //delete
            CreateMap<Entities.TypeOfStuffMember, TypeOfStuffMemberResponse>();
            //get
            CreateMap<Entities.TypeOfStuffMember, TypeOfStuffMemberResponse>();
        }
       
    }
}

