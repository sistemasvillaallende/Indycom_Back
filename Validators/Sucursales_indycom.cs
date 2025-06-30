using FluentValidation;
using Web_Api_IyC.Entities;

public class Sucursales_indycomValidator : AbstractValidator<Sucursales_indycom>
{
    public Sucursales_indycomValidator()
    {
        RuleFor(x => x.Legajo)
            .GreaterThan(0)
            .When(x => x.Legajo != 0)
            .WithMessage("El legajo debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.Nro_sucursal)
            .GreaterThan(0)
            .When(x => x.Nro_sucursal.HasValue && x.Nro_sucursal.Value != 0)
            .WithMessage("El número de sucursal debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.Des_com)
            .NotEmpty()
            .When(x => x.Des_com != null)
            .WithMessage("La descripción comercial no puede estar vacía si se proporciona.");

        RuleFor(x => x.Nom_fantasia)
            .NotEmpty()
            .When(x => x.Nom_fantasia != null)
            .WithMessage("El nombre de fantasía no puede estar vacío si se proporciona.");

        RuleFor(x => x.Cod_calle)
            .GreaterThan(0)
            .When(x => x.Cod_calle != 0)
            .WithMessage("El código de calle debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.Nom_calle)
            .NotEmpty()
            .When(x => x.Nom_calle != null)
            .WithMessage("El nombre de calle no puede estar vacío si se proporciona.");

        RuleFor(x => x.Nro_dom)
            .GreaterThan(0)
            .When(x => x.Nro_dom != 0)
            .WithMessage("El número de domicilio debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.Cod_barrio)
            .GreaterThan(0)
            .When(x => x.Cod_barrio != 0)
            .WithMessage("El código de barrio debe ser mayor a 0 si se proporciona.");

        RuleFor(x => x.Nom_barrio)
            .NotEmpty()
            .When(x => x.Nom_barrio != null)
            .WithMessage("El nombre de barrio no puede estar vacío si se proporciona.");

        RuleFor(x => x.Ciudad)
            .NotEmpty()
            .When(x => x.Ciudad != null)
            .WithMessage("La ciudad no puede estar vacía si se proporciona.");

        RuleFor(x => x.Provincia)
            .NotEmpty()
            .When(x => x.Provincia != null)
            .WithMessage("La provincia no puede estar vacía si se proporciona.");

        RuleFor(x => x.Pais)
            .NotEmpty()
            .When(x => x.Pais != null)
            .WithMessage("El país no puede estar vacío si se proporciona.");

        RuleFor(x => x.Cod_postal)
            .NotEmpty()
            .When(x => x.Cod_postal != null)
            .WithMessage("El código postal no puede estar vacío si se proporciona.");

        RuleFor(x => x.Nro_res)
            .NotEmpty()
            .When(x => x.Nro_res != null)
            .WithMessage("El número de resolución no puede estar vacío si se proporciona.");

        RuleFor(x => x.Fecha_inicio)
            .LessThanOrEqualTo(DateTime.Now)
            .When(x => x.Fecha_inicio.HasValue)
            .WithMessage("La fecha de inicio no puede ser futura.");

        RuleFor(x => x.Fecha_Baja)
            .LessThanOrEqualTo(DateTime.Now)
            .When(x => x.Fecha_Baja.HasValue)
            .WithMessage("La fecha de baja no puede ser futura.");

        RuleFor(x => x.Fecha_hab)
            .LessThanOrEqualTo(DateTime.Now)
            .When(x => x.Fecha_hab.HasValue)
            .WithMessage("La fecha de habilitación no puede ser futura.");

        // Dado_baja es bool, no hace falta validar.

        RuleFor(x => x.nro_exp_mesa_ent)
            .NotEmpty()
            .When(x => x.nro_exp_mesa_ent != null)
            .WithMessage("El número de expediente mesa entrada no puede estar vacío si se proporciona.");

        RuleFor(x => x.fecha_alta)
            .LessThanOrEqualTo(DateTime.Now)
            .When(x => x.fecha_alta.HasValue)
            .WithMessage("La fecha de alta no puede ser futura.");

        RuleFor(x => x.cod_zona)
            .NotEmpty()
            .When(x => x.cod_zona != null)
            .WithMessage("El código de zona no puede estar vacío si se proporciona.");

        RuleFor(x => x.Nro_local)
            .NotEmpty()
            .When(x => x.Nro_local != null)
            .WithMessage("El número de local no puede estar vacío si se proporciona.");

        RuleFor(x => x.Piso_dpto)
            .NotEmpty()
            .When(x => x.Piso_dpto != null)
            .WithMessage("El piso o departamento no puede estar vacío si se proporciona.");

        RuleFor(x => x.Vto_inscripcion)
            .LessThanOrEqualTo(DateTime.Now)
            .When(x => x.Vto_inscripcion.HasValue)
            .WithMessage("La fecha de vencimiento de inscripción no puede ser futura.");
    }
}
