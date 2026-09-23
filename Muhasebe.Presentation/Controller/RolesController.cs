using MediatR;
using Microsoft.AspNetCore.Mvc;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using Muhasebe.Presentation.Abstraction;

namespace Muhasebe.Presentation.Controller
{
    public sealed class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand request)
        {
            CreateRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesQuery request = new GetAllRolesQuery();
            GetAllRolesQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand request)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var request = new DeleteRoleCommand(roleId);
            
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
