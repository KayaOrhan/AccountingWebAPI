using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed record CreateCompanyCommand(
        string Name,
        string ServerName,
        string DatabaseName,
        string UserId,
        string Password
    ) : ICommand<CreateCompanyCommandResponse>;
}
