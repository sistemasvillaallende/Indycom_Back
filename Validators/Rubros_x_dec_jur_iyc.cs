using FluentValidation;
using Web_Api_IyC.Entities;

public class Rubros_x_dec_jur_iycValidator : AbstractValidator<Rubros_x_dec_jur_iyc>
{
    public Rubros_x_dec_jur_iycValidator()
    {
        RuleFor(x => x.nro_transaccion)
            .GreaterThan(0)
            .When(x => x.nro_transaccion != 0)
            .WithMessage("El número de transacción debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.cod_rubro)
            .GreaterThan(0)
            .When(x => x.cod_rubro != 0)
            .WithMessage("El código de rubro debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.cantidad)
            .GreaterThan(0)
            .When(x => x.cantidad != 0)
            .WithMessage("La cantidad debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.importe)
            .GreaterThan(0)
            .When(x => x.importe != 0)
            .WithMessage("El importe debe ser mayor a 0 si se proporciona.");
    }
}