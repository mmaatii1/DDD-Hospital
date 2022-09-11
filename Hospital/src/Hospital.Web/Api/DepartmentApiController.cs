using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.CQRS.Department.Queries;
using PatientManagement.Core.CQRS.Department.Requests;

namespace Hospital.Web.Api;

public class DepartmentApiController : BaseApiController
{
  public DepartmentApiController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {

  }

  [HttpGet]
  public async Task<IActionResult> GetAllDepartments()
  {
    var query = new GetAllDepartmentsQuery();
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
  {
    var command = _mapper.Map<CreateDepartmentCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction(nameof(CreateDepartment), new { id = response.Id }, response);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request, [FromRoute] int id)
  {
    var command = _mapper.Map<UpdateDepartmentCommand>(request);
    command.Id = id;
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
  {
    var command = new DeleteDepartmentCommand(id);
    var response = await _mediator.Send(command);
    return Ok(response);
  }

}
