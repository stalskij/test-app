using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности точки измерения электроэнергии
    /// </summary>
    public partial class PowerMeasurementPointMap : EntityTypeConfiguration<PowerMeasurementPoint>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<PowerMeasurementPoint> builder)
        {
            builder.ToTable(nameof(PowerMeasurementPoint));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(400);
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(p => p.ConsumptionObject)
                .WithMany()
                .HasForeignKey(p => p.ConsumptionObjectId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}
