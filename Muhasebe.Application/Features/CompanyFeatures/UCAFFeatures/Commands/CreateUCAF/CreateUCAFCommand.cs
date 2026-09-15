using Muhasebe.Application.Messaging;

namespace Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed record CreateUCAFCommand(string Code, string Name, char Type, string CompanyId) : ICommand<CreateUCAFCommandResponse>;
}
