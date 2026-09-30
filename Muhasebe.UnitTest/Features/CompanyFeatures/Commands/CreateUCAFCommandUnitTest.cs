

using Moq;
using Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Muhasebe.Application.Services.CompanyServices;
using Muhasebe.Domain.CompanyEntities;
using Shouldly;

namespace Muhasebe.UnitTest.Features.CompanyFeatures.Commands
{
    public class CreateUCAFCommandUnitTest
    {
        private readonly Mock<IUCAFService> _ucafServiceMock;

        public CreateUCAFCommandUnitTest()
        {
            _ucafServiceMock = new();
        }


        [Fact]
        public async Task UcafShouldBeNull()
        {
            UniformChartOfAccount ucaf = await _ucafServiceMock.Object.GetByCode("1234567.1223");
            ucaf.ShouldBeNull();
        }

        [Fact]
        public async Task CreateUCAFCommandResponseShouldNotBeNull()
        {
            var command = new CreateUCAFCommand
            (
                Code : "1234567.1223",
                Name : "Test UCAF",
                Type : 'A',
                CompanyId : "TestCompanyId"
            );

            var handler = new CreateUCAFCommandHandler(_ucafServiceMock.Object);
            var response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
        }
    }
}
