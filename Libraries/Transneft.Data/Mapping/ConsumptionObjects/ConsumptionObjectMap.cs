using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности объекта потребления
    /// </summary>
    public partial class ConsumptionObjectMap : EntityTypeConfiguration<ConsumptionObject>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<ConsumptionObject> builder)
        {
            builder.ToTable(nameof(ConsumptionObject));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(400);
            builder.Property(c => c.Address).HasMaxLength(1000);
            builder.Property(c => c.Name).IsRequired();

            builder.HasOne(c => c.AffiliatedCompany)
                .WithMany(p => p.ConsumptionObjects)
                .HasForeignKey(c => c.AffiliatedCompanyId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
