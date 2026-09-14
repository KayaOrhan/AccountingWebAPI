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
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            CreateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRolesRequest request = new GetAllRolesRequest();
            GetAllRolesResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRole(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var request = new DeleteRoleRequest
            {
                Id = roleId
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
