using Microsoft.EntityFrameworkCore;
using Muhasebe.Domain.Abstraction;
using Muhasebe.Domain.Repositories;
using Muhasebe.Persistance.Context;

namespace Muhasebe.Persistance.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T>
        where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((CompanyDbContext context, string id) =>
                context.Set<T>().FirstOrDefault(e => e.Id == id));

        private  CompanyDbContext _companyDbContext;

        public required DbSet<T> Entity { get; set; }

        public void SetCompanyDbContextInstance(DbContext context)
        {
            _companyDbContext = (CompanyDbContext)context;
            Entity = _companyDbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveById(string id)
        {
            T entity = await GetByIdCompiled(_companyDbContext, id);
            if(entity != null)
            {
                Entity.Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}
