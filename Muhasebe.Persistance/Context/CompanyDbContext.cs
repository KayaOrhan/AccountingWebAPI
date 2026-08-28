
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Muhasebe.Domain.Abstraction;
using Muhasebe.Domain.AppEntities;

namespace Muhasebe.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString;
        public CompanyDbContext(Company company = null)
        {
            if(company != null)
            {
                if (!string.IsNullOrWhiteSpace(company?.UserId) && !string.IsNullOrWhiteSpace(company?.Password))
                {
                    ConnectionString = $"Data Source={company?.ServerName};Initial Catalog={company?.DatabaseName};User ID={company?.UserId};Password={company?.Password};Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                }
                else
                {
                    ConnectionString = $"Data Source={company?.ServerName};Initial Catalog={company?.DatabaseName};Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                }
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
