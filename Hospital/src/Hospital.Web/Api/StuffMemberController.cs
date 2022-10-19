using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Queries;
using PatientManagement.Core.CQRS.StuffMember.Requests;

namespace Hospital.Web.Api;

public class StuffMemberController : BaseApiController
{
  public StuffMemberController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {

  }

  [HttpGet]
  public async Task<IActionResult> GetAllStuffMembers()
  {
    var query = new GetAllStuffMembersQuery();
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetStuffMemberById([FromRoute] int id)
  {
    var query = new GetStuffMemberByIdQuery(id);
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreateStuffMember([FromBody] CreateStuffMemberRequest request)
  {
    var command = _mapper.Map<CreateStuffMemberCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction(nameof(CreateStuffMember), new { id = response.Id }, response);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateStuffMember([FromBody] UpdateStuffMemberRequest request, [FromRoute] int id)
  {
    var command = _mapper.Map<UpdateStuffMemberCommand>(request);
    command.Id = id;
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteStuffMember([FromRoute] int id)
  {
    var command = new DeleteStuffMemberCommand(id);
    var response = await _mediator.Send(command);
    return Ok(response);
  }

}

