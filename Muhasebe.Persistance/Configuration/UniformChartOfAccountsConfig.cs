using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muhasebe.Domain.CompanyEntities;
using Muhasebe.Persistance.Constants;

namespace Muhasebe.Persistance.Configuration
{
    public sealed class UniformChartOfAccountsConfig : IEntityTypeConfiguration<UniformChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
        {
            builder.ToTable(TableNames.UniformChartOfAccounts);
            builder.HasKey(p => p.Id);
        }
    }
}
