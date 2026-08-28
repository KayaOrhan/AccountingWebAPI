using MediatR;
using Microsoft.AspNetCore.Mvc;
using Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Muhasebe.Presentation.Abstraction;

namespace Muhasebe.Presentation.Controller
{
    public sealed class UCAFsController : ApiController
    {
        public UCAFsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAFsAsync(CreateUCAFRequest request)
        {
            CreateUCAFResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}