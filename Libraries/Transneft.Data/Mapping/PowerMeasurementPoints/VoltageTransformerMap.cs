using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности трансформатора напряжения
    /// </summary>
    public partial class VoltageTransformerMap : EntityTypeConfiguration<VoltageTransformer>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<VoltageTransformer> builder)
        {
            builder.ToTable(nameof(VoltageTransformer));
            builder.HasKey(voltageTransformer => voltageTransformer.Id);

            builder.Property(voltageTransformer => voltageTransformer.Number).HasMaxLength(100);
            builder.Property(voltageTransformer => voltageTransformer.Number).IsRequired();

            builder.HasOne(c => c.PowerMeasurementPoint)
                .WithOne(p => p.VoltageTransformer)
                .HasForeignKey<PowerMeasurementPoint>(с => с.VoltageTransformerId);

            base.Configure(builder);
        }

        #endregion
    }
}
