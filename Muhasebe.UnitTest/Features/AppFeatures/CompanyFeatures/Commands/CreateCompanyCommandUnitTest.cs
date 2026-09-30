
using Moq;
using Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities;
using Shouldly;

namespace Muhasebe.UnitTest.Features.AppFeatures.CompanyFeatures.Commands
{
    public class CreateCompanyCommandUnitTest
    {
        private readonly Mock<ICompanyService> _companyServiceMock;

        public CreateCompanyCommandUnitTest()
        {
            _companyServiceMock = new();
        }

        [Fact]
        public async Task CompanyShouldBeNull()
        {
            Company company = await _companyServiceMock.Object.GetCompanyByName("kekstra");

            company.ShouldBeNull();
        }

        [Fact]
        public async Task CreateCompanyCommandResponseShouldNotBeNull()
        {
            var command = new CreateCompanyCommand(
                Name: "kekstra",
                ServerName: "localhost",
                DatabaseName: "kekstra_db",
                UserId: "",
                Password: ""
            );
            var handler = new CreateCompanyCommandHandler(_companyServiceMock.Object);
            var response = await handler.Handle(command, default);

            response.ShouldNotBeNull();
        }
    }
}
