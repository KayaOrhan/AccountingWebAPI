using Moq;
using Muhasebe.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using Muhasebe.Application.Services.AppServices;
using Shouldly;

namespace Muhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles
{
    public class GetAllRolesQueryUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;
        public GetAllRolesQueryUnitTest()
        {
            _roleServiceMock = new();
        }
        [Fact]
        public async Task GetAllRolesQueryResponseShouldNotBeNull()
        {
            var query = new GetAllRolesQuery();
            var handler = new GetAllRolesQueryHandler(_roleServiceMock.Object);
            var response = await handler.Handle(query, default);
            response.ShouldNotBeNull();
        }
    }
}
