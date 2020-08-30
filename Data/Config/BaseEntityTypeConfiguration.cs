using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EjemploMVCCursosOnline.Data.Config
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property<DateTime>("FechaCreacion")
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("GETUTCDATE()")
                   .IsRequired();

            builder.Property<string>("UsuarioCreacion")
                   .HasMaxLength(256)
                   .IsRequired();


            builder.Property<DateTime>("FechaModificacion")
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("GETUTCDATE()")
                   .IsRequired();

            builder.Property<string>("UsuarioModificacion")
                   .HasMaxLength(256)
                   .IsRequired();

            builder.Property<bool>("EstaBorrado")
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "EstaBorrado") == false);

        }
    }
}
