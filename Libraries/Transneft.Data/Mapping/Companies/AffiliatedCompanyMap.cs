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

            builder.Property(c => c.Name).HasMaxLength(400);
            builder.Property(c => c.Address).HasMaxLength(1000);
            builder.Property(c => c.Name).IsRequired();

            builder.HasOne(p => p.Company)
                .WithMany(c => c.AffiliatedCompanies)
                .HasForeignKey(company => company.CompanyId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
