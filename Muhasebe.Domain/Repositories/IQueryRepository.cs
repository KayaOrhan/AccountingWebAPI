using Muhasebe.Domain.Abstraction;
using System.Linq.Expressions;

namespace Muhasebe.Domain.Repositories
{
    public interface IQueryRepository<T> : IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetAll(bool isTracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true);
        Task<T> GetById(string id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, bool isTracking = true);

        Task<T> GetFirst(bool isTracking = true);
    }
}
