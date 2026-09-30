
using Moq;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;
using Shouldly;

namespace Muhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public class CreateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public CreateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldBeNull()
        {
            AppRole role = await _roleServiceMock.Object.GetByCode("UCAF.Create");

            role.ShouldBeNull();
        }

        [Fact]
        public async Task CreateRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateRoleCommand(
                Code: "UCAF.Create",
                Name: "Create"
            );
            var handler = new CreateRoleCommandHandler(_roleServiceMock.Object);
            var response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
        }
    }
}
