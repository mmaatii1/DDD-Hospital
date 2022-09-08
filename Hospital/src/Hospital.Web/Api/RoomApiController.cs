using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.Room.Commands;
using PatientManagement.Core.CQRS.Room.Queries;
using PatientManagement.Core.CQRS.Room.Requests;

namespace Hospital.Web.Api;

public class RoomApiController : BaseApiController
{
  public RoomApiController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {

  }

  [HttpGet]
  public async Task<IActionResult> GetAllRooms()
  {
    var query = new GetAllRoomsQuery();
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreateRoom([FromBody] CreateRoomRequest request)
  {
    var command = _mapper.Map<CreateRoomCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction(nameof(CreateRoom), new { id = response.Id }, response);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomRequest request, [FromRoute] int id)
  {
    var command = _mapper.Map<UpdateRoomCommand>(request);
    command.Id = id;
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRoom([FromRoute] int id)
  {
    var command = new DeleteRoomCommand(id);
    var response = await _mediator.Send(command);
    return Ok(response);
  }
}
