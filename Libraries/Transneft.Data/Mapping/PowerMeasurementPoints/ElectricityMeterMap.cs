using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности счетчика электрической энергии
    /// </summary>
    public partial class ElectricityMeterMap : EntityTypeConfiguration<ElectricityMeter>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<ElectricityMeter> builder)
        {
            builder.ToTable(nameof(ElectricityMeter));
            builder.HasKey(electricityMeter => electricityMeter.Id);

            builder.Property(electricityMeter => electricityMeter.Number).HasMaxLength(100);
            builder.Property(electricityMeter => electricityMeter.Number).IsRequired();

            builder.HasOne(c => c.PowerMeasurementPoint)
                .WithOne(p => p.ElectricityMeter)
                .HasForeignKey<PowerMeasurementPoint>(с => с.ElectricityMeterId);

            base.Configure(builder);
        }

        #endregion
    }
}
