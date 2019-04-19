using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.Companies;
using Transneft.Core.Domain.PowerSuplplyPoints;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности точки поставки электроэнергии
    /// </summary>
    public partial class PowerSuplplyPointMap : EntityTypeConfiguration<PowerSupplyPoint>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<PowerSupplyPoint> builder)
        {
            builder.ToTable(nameof(PowerSupplyPoint));
            builder.HasKey(powerSuplplyPoint => powerSuplplyPoint.Id);

            builder.Property(powerSuplplyPoint => powerSuplplyPoint.Name).HasMaxLength(400);
            builder.Property(powerSuplplyPoint => powerSuplplyPoint.Name).IsRequired();

            builder.HasOne(powerSuplplyPoint => powerSuplplyPoint.ConsumptionObject)
                .WithMany()
                .HasForeignKey(powerSuplplyPoint => powerSuplplyPoint.ConsumptionObjectId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
