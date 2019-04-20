using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.Companies;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности головной организации
    /// </summary>
    public partial class CompanyMap : EntityTypeConfiguration<Company>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));
            builder.HasKey(company => company.Id);

            builder.Property(c => c.Name).HasMaxLength(400);
            builder.Property(c => c.Address).HasMaxLength(1000);
            builder.Property(c => c.Name).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
