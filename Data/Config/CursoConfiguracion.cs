using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EjemploMVCCursosOnline.Data.Config
{
    public class CursoConfiguracion : BaseEntityTypeConfiguration<Curso>
    {
        public override void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(t => t.Titulo)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(t => t.Descripcion)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(t => t.FechaPublicacion)
                .IsRequired();


            // Importante añadirlo para heredar las propiedades
            base.Configure(builder);
        }
    }
}
