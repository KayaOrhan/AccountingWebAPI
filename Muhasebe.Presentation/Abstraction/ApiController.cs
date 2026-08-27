using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Muhasebe.Presentation.Abstraction
{

    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
