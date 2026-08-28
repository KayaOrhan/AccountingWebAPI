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
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
             context.Set<T>().FirstOrDefault(e => e.Id == id));


        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context) =>
             context.Set<T>().FirstOrDefault());


        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, Task<T>> GetFirstByExpressionCompiled =
         EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> predicate) =>
             context.Set<T>().FirstOrDefault(predicate));

        private CompanyDbContext _companyDbContext;

        public DbSet<T> Entity { get; set; }
        
        public void SetCompanyDbContextInstance(DbContext context)
        {
            _companyDbContext = (CompanyDbContext)context;
            Entity = _companyDbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public async Task<T> GetById(string id)
        {
            return await GetByIdCompiled(_companyDbContext, id);

        }

        public async Task<T> GetFirst()
        {
            return await GetFirstCompiled(_companyDbContext);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> predicate)
        {
            return await GetFirstByExpressionCompiled(_companyDbContext, predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Entity.Where(predicate);
        }
    }
}
