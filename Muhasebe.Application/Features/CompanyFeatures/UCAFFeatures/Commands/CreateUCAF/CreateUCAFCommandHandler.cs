using Muhasebe.Application.Messaging;
using Muhasebe.Application.Services.CompanyServices;
using Muhasebe.Domain.CompanyEntities;

namespace Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;

        public CreateUCAFCommandHandler(IUCAFService ucafService)
        {
            _ucafService = ucafService;
        }

        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            UniformChartOfAccount ucaf = await _ucafService.GetByCode(request.Code);
            if(ucaf != null)
            {
                throw new InvalidOperationException("UCAF with the specified code already exists.");
            }

            await _ucafService.CreateUCAFAsync(request, cancellationToken);
            return new();

        }
    }
}
