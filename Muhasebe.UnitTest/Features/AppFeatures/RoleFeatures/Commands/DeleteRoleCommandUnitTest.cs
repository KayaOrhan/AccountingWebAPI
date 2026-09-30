using Moq;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities.Identity;
using Shouldly;

namespace Muhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public class DeleteRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public DeleteRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldNotBeNull()
        {
            _roleServiceMock.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
        }

        [Fact]
        public async Task DeleteRoleCommandResponseShouldNotBeNull()
        {
            var command = new DeleteRoleCommand ( Id : Guid.NewGuid().ToString() );

            _roleServiceMock.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
            _roleServiceMock.Setup(x => x.DeleteAsync(It.IsAny<AppRole>())).Returns(Task.CompletedTask);

            var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);

            var response = await handler.Handle(command, default);

            response.ShouldNotBeNull();

        }
    }
}
