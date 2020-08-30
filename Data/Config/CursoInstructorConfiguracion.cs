using EjemploMVCCursosOnline.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EjemploMVCCursosOnline.Data.Config
{
    public class CursoInstructorConfiguracion : BaseEntityTypeConfiguration<CursoInstructor>
    {
        public override void Configure(EntityTypeBuilder<CursoInstructor> builder)
        {

            builder.HasKey(p => new { p.CursoId, p.InstructorId });

            // Importante añadirlo para heredar las propiedades
            base.Configure(builder);
        }
    }
}
