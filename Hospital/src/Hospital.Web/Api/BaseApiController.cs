using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Api
{
    /// <summary>
    /// If your API controllers will use a consistent route convention and the [ApiController] attribute (they should)
    /// then it's a good idea to define and use a common base controller class like this one.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public abstract class BaseApiController : Controller
    {
      protected readonly IMediator _mediator;
      protected readonly IMapper _mapper;

      protected BaseApiController(IMediator mediator, IMapper mapper)
      {
          _mapper = mapper;
          _mediator = mediator;
      }
    }
}
