using MediatR;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities;

namespace Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            Company company = await _companyService.GetCompanyByName(request.Name);
            
            if (company is not null)
            {
                throw new Exception("A company with this name already exists.");
            }

            await _companyService.CreateCompany(request);
            return new();
        }
    }
}
