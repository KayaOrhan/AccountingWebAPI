using Muhasebe.Application.Messaging;
using Muhasebe.Application.Services.AppServices;
using Muhasebe.Domain.AppEntities;


namespace Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company company = await _companyService.GetCompanyByName(request.Name);
            
            if (company is not null)
            {
                throw new Exception("A company with this name already exists.");
            }

            await _companyService.CreateCompany(request, cancellationToken);
            return new();
        }
    }
}
