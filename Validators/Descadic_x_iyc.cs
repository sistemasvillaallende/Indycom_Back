using FluentValidation;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Validators;

public class Descadic_x_iycValidator : AbstractValidator<Descadic_x_iyc>
{
    public Descadic_x_iycValidator()
    {
        RuleFor(x => x.legajo)
            .GreaterThan(0)
            .When(x => x.legajo != 0)
            .WithMessage("El legajo debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.cod_concepto_iyc)
            .GreaterThan(0)
            .When(x => x.cod_concepto_iyc != 0)
            .WithMessage("El código de concepto debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.des_concepto_iyc)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.des_concepto_iyc))
            .WithMessage("La descripción no debe exceder los 100 caracteres.");

        RuleFor(x => x.porcentaje)
            .InclusiveBetween(0, 100)
            .When(x => x.porcentaje != 0)
            .WithMessage("El porcentaje debe estar entre 0 y 100.");

        RuleFor(x => x.monto)
            .GreaterThanOrEqualTo(0)
            .When(x => x.monto != 0)
            .WithMessage("El monto debe ser mayor o igual a 0.");

        RuleFor(x => x.vencimiento)
            .Must(date => date != default)
            .When(x => x.vencimiento != DateTime.MinValue)
            .WithMessage("La fecha de vencimiento debe ser válida.");

        RuleFor(x => x.nro_decreto)
            .GreaterThan(0)
            .When(x => x.nro_decreto != 0)
            .WithMessage("El número de decreto debe ser mayor a 0 si se proporciona.");

        When(x => x.objAuditoria != null, () =>
        {
            RuleFor(x => x.objAuditoria).SetValidator(new AuditoriaValidator());
        });

    }
}
