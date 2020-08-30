using FluentValidation;

namespace EjemploMVCCursosOnline.Models.Validaciones
{
    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.Descripcion).NotEmpty();
            RuleFor(x => x.FechaPublicacion).NotEmpty();
        }
    }
}
