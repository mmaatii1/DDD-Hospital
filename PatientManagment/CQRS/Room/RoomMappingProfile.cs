using AutoMapper;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.CQRS.Room.Requests;
using PatientManagement.Core.CQRS.Room.Responses;

namespace PatientManagement.Core.CQRS.Room
{
    public class RoomMappingProfile : Profile
    {
        public RoomMappingProfile()
        {
            //create
            CreateMap<CreateRoomCommand, Entities.Room>();
            CreateMap<Entities.Room, RoomResponse>();
            CreateMap<CreateRoomRequest, CreateRoomCommand>();
            //update
            CreateMap<UpdateRoomCommand, Entities.Room>();
            CreateMap<UpdateRoomCommand, RoomResponse>();
            CreateMap<UpdateRoomRequest, UpdateRoomCommand>();
            //delete
            CreateMap<Entities.Room, RoomResponse>();
            //get
            CreateMap<Entities.Room, RoomResponse>();
        }
    }
}
