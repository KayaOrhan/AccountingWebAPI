using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain.Abstraction;
using Muhasebe.Domain.Repositories;
using Muhasebe.Persistance.Context;
using System.Linq.Expressions;

namespace Muhasebe.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
             isTracking ? context.Set<T>().FirstOrDefault(e => e.Id == id) : context.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == id));


        private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
             isTracking ? context.Set<T>().FirstOrDefault() : context.Set<T>().AsNoTracking().FirstOrDefault());


        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, bool, Task<T>> GetFirstByExpressionCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> predicate, bool isTracking) =>
             isTracking ? context.Set<T>().FirstOrDefault(predicate) : context.Set<T>().AsNoTracking().FirstOrDefault(predicate));

        private CompanyDbContext _companyDbContext;

        public DbSet<T> Entity { get; set; }
        
        public void SetCompanyDbContextInstance(DbContext context)
        {
            _companyDbContext = (CompanyDbContext)context;
            Entity = _companyDbContext.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var query = Entity.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await GetByIdCompiled(_companyDbContext, id, isTracking);

        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await GetFirstCompiled(_companyDbContext, isTracking);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            return await GetFirstByExpressionCompiled(_companyDbContext, predicate, isTracking);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
        {
            var query = Entity.Where(predicate);
            if (!isTracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
