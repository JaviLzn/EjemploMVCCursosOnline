using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EjemploMVCCursosOnline.Data.Config
{
    public class PrecioConfiguracion : BaseEntityTypeConfiguration<Precio>
    {
        public override void Configure(EntityTypeBuilder<Precio> builder)
        {
            builder.Property(t => t.PrecioNormal)
              .HasColumnType("decimal(9, 2)")
              .IsRequired();

            builder.Property(t => t.PrecioPromocion)
            .HasColumnType("decimal(9, 2)")
            .IsRequired();

            // Importante añadirlo
            base.Configure(builder);
        }
    }
}
