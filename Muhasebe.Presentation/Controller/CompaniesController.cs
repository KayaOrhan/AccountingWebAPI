using MediatR;
using Microsoft.AspNetCore.Mvc;
using Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
using Muhasebe.Presentation.Abstraction;

namespace Muhasebe.Presentation.Controller
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommand req, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(req, cancellationToken);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabases()
        {
            var response = await _mediator.Send(new MigrateCompanyDatabasesCommand());
            return Ok(response);
        }
    }
}
 