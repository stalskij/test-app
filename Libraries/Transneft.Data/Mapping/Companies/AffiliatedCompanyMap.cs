using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.Companies;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности дочерней организации
    /// </summary>
    public class AffiliatedCompanyMap : EntityTypeConfiguration<AffiliatedCompany>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<AffiliatedCompany> builder)
        {
            builder.ToTable(nameof(AffiliatedCompany));
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Company)
                .WithMany(c => c.AffiliatedCompanies)
                .HasForeignKey(company => company.CompanyId);

            base.Configure(builder);
        }

        #endregion
    }
}
