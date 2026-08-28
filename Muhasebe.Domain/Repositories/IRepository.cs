using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain.Abstraction;

namespace Muhasebe.Domain.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        void SetCompanyDbContextInstance(DbContext context);

        DbSet<T> Entity { get; set; }

    }
}
