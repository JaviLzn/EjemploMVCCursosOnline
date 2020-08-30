using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EjemploMVCCursosOnline.Data.Config
{
    public class InstructorConfiguracion : BaseEntityTypeConfiguration<Instructor>
    {
        public override void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(p => p.NombreCompleto)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(p => p.Profesion)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(p => p.Cargo)
                   .HasMaxLength(256)
                   .IsRequired();

            // Importante añadirlo para heredar las propiedades
            base.Configure(builder);
        }

    }
}
