using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Data.Mapping.Companies
{
    /// <summary>
    /// Представляет конфигурацию сущности трансформатора тока
    /// </summary>
    public partial class CurrentTransformerMap : EntityTypeConfiguration<CurrentTransformer>
    {
        #region Methods

        /// <summary>
        /// Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public override void Configure(EntityTypeBuilder<CurrentTransformer> builder)
        {
            builder.ToTable(nameof(CurrentTransformer));
            builder.HasKey(с => с.Id);

            builder.Property(с => с.Number).HasMaxLength(100);
            builder.Property(с => с.Number).IsRequired();

            builder.HasOne(c => c.PowerMeasurementPoint)
                .WithOne(p => p.CurrentTransformer)
                .HasForeignKey<PowerMeasurementPoint>(с => с.CurrentTransformerId);

            base.Configure(builder);
        }

        #endregion
    }
}
