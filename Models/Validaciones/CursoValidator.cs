using FluentValidation;

namespace EjemploMVCCursosOnline.Models.Validaciones
{
    public class CursoValidator : AbstractValidator<Curso>
    {
        public CursoValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty().WithMessage("Debe especificar el título del curso.");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("Debe especificar la descripción del curso.");
            RuleFor(x => x.FechaPublicacion).NotEmpty().WithMessage("Debe seleccionar una fecha de publicación.");
        }
    }
}
