using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EjemploMVCCursosOnline.Data.Config
{
    public class ComentarioConfiguration : BaseEntityTypeConfiguration<Comentario>
    {
        public override void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.Property(t => t.TextoComentario)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(t => t.NombrePersona)
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property(t => t.Puntaje)
                   .HasColumnType("decimal(3, 1)")
                   .IsRequired();


            // Importante añadirlo para heredar las propiedades
            base.Configure(builder);
        }

    }
}
