using Microsoft.EntityFrameworkCore;

namespace Muhasebe.Domain
{
    public interface IUnitOfWork
    {
        void SetCompanyDbContextInstance(DbContext context);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
