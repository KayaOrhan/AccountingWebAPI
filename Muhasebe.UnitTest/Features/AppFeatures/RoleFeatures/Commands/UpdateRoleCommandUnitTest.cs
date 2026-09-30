using Moq;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;
using Shouldly;

namespace Muhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public class UpdateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;
        public UpdateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            _roleServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .ReturnsAsync(new AppRole());
        }

        [Fact]
        public async Task AppRoleCodeShouldBeUnique()
        {
            AppRole role = await _roleServiceMock.Object.GetByCode("UCAF.Update");
            role.ShouldBeNull();
        }

        [Fact]
        public async Task UpdateRoleCommandResponseShouldNotBeNull()
        {
            var command = new UpdateRoleCommand(
                Id: Guid.NewGuid().ToString(),
                Code: "UCAF.Update",
                Name: "Update"
            );
            var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);
            var response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
        }
    }
}
