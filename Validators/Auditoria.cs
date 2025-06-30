using FluentValidation;
using Web_Api_IyC.Entities.AUDITORIA;

namespace Web_Api_IyC.Validators
{
    public class AuditoriaValidator : AbstractValidator<Auditoria>
    {
        public AuditoriaValidator()
        {
            RuleFor(x => x.id_auditoria)
                .GreaterThanOrEqualTo(0).WithMessage("El id de auditoría debe ser mayor o igual a 0.");

            RuleFor(x => x.fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.")
                .Must(BeAValidDate).WithMessage("La fecha debe tener un formato válido.");

            RuleFor(x => x.usuario)
                .NotEmpty().WithMessage("El usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El usuario puede tener máximo 50 caracteres.");

            RuleFor(x => x.proceso)
                .MaximumLength(100).WithMessage("El proceso puede tener máximo 100 caracteres.");

            RuleFor(x => x.identificacion)
                .MaximumLength(100).WithMessage("La identificación puede tener máximo 100 caracteres.");

            RuleFor(x => x.autorizaciones)
                .MaximumLength(500).WithMessage("Las autorizaciones pueden tener máximo 500 caracteres.");

            RuleFor(x => x.observaciones)
                .MaximumLength(500).WithMessage("Las observaciones pueden tener máximo 500 caracteres.");

            RuleFor(x => x.detalle)
                .MaximumLength(1000).WithMessage("El detalle puede tener máximo 1000 caracteres.");

            RuleFor(x => x.ip)
                .MaximumLength(45).WithMessage("La IP puede tener máximo 45 caracteres.");
        }

        private bool BeAValidDate(string fecha)
        {
            return DateTime.TryParse(fecha, out _);
        }
    
    }
}
