using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Queries;
using PatientManagement.Core.CQRS.Patient.Requests;

namespace Hospital.Web.Api;

public class PatientController : BaseApiController
{
  public PatientController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {

  }

  [HttpGet]
  public async Task<IActionResult> GetAllPatients()
  {
    var query = new GetAllPatientsQuery();
    var response = await _mediator.Send(query);
    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreatePatient([FromBody] CreatePatientRequest request)
  {
    var command = _mapper.Map<CreatePatientCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction(nameof(CreatePatient), new { id = response.Id }, response);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientRequest request, [FromRoute] int id)
  {
    var command = _mapper.Map<UpdatePatientCommand>(request);
    command.Id = id;
    var response = await _mediator.Send(command);
    return Ok(response);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePatient([FromRoute] int id)
  {
    var command = new DeletePatientCommand(id);
    var response = await _mediator.Send(command);
    return Ok(response);
  }
  
}
