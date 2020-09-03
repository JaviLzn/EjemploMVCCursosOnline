using FluentValidation;

namespace EjemploMVCCursosOnline.Models.Validaciones
{
    public class InstructorValidator : AbstractValidator<Instructor>
    {
        public InstructorValidator()
        {
            RuleFor(x => x.NombreCompleto).NotEmpty(); //.WithMessage("Debe especificar el título del curso.");
        }
    }
}
