using Mapster;
using Muhasebe.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using Muhasebe.Application.Services.CompanyServices;
using Muhasebe.Domain;
using Muhasebe.Domain.CompanyEntities;
using Muhasebe.Domain.Repositories.UCAFRepositories;
using Muhasebe.Persistance.Context;

namespace Muhasebe.Persistance.Services.CompanyService
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _ucafCommandRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private CompanyDbContext _companyDbContext;
        public UCAFService(IUCAFCommandRepository ucafCommandRepository, IContextService contextService, IUnitOfWork unitOfWork)
        {
            _ucafCommandRepository = ucafCommandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUCAFAsync(CreateUCAFCommand request)
        {
            _companyDbContext = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);

            _ucafCommandRepository.SetCompanyDbContextInstance(_companyDbContext);
            
            _unitOfWork.SetCompanyDbContextInstance(_companyDbContext);
            
            UniformChartOfAccount uniformChartOfAccount = request.Adapt<UniformChartOfAccount>();
            uniformChartOfAccount.Id = Guid.NewGuid().ToString();

            await _ucafCommandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
