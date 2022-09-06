using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Requests;

namespace Hospital.Web.Api;

public class PatientApiController : BaseApiController
{
  public PatientApiController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
  {
    
  }

  [HttpPost]
  public async Task<IActionResult> CreatePatient([FromBody] CreatePatientRequest request)
  {
    var command = _mapper.Map<CreatePatientCommand>(request);
    var response = await _mediator.Send(command);
    return CreatedAtAction($"api/PatientApi/{response.Id}", response);
  }

  
}
