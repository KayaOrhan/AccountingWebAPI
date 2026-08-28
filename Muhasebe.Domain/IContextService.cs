

using Microsoft.EntityFrameworkCore;

namespace Muhasebe.Domain
{
    public interface IContextService
    {
        DbContext CreateDbContextInstance(string companyId);
    }
}
