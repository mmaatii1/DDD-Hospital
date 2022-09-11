using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Queries;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Requests;

namespace Hospital.Web.Api;

public class TypeOfStuffMemberController : BaseApiController
{
  public TypeOfStuffMemberController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {

  }

  [HttpGet]
  public async Task<IActionResult> GetTypeOfStuffMembers()
  {
    var query = new GetAllTypesOfStuffMembersQuery();
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreateTypeOfStuffMember([FromBody] CreateTypeOfStuffMemberRequest request)
  {
    var command = _mapper.Map<CreateTypeOfStuffMemberCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction(nameof(CreateTypeOfStuffMember), new { id = response.Id }, response);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateTypeOfStuffMember([FromBody] UpdateTypeOfStuffMemberRequest request, [FromRoute] int id)
  {
    var command = _mapper.Map<UpdateTypeOfStuffMemberCommand>(request);
    command.Id = id;
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTypeOfStuffMember([FromRoute] int id)
  {
    var command = new DeleteTypeOfStuffMemberCommand(id);
    var response = await _mediator.Send(command);
    return Ok(response);
  }
}

