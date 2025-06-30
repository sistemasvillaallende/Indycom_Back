using FluentValidation;
using Web_Api_IyC.Entities;

public class Ctasctes_indycomValidator : AbstractValidator<Ctasctes_indycom>
{
    public Ctasctes_indycomValidator()
    {
        RuleFor(x => x.tipo_transaccion)
            .GreaterThan(0)
            .When(x => x.tipo_transaccion != 0);

        RuleFor(x => x.nro_transaccion)
            .GreaterThan(0)
            .When(x => x.nro_transaccion != 0);

        RuleFor(x => x.nro_pago_parcial)
            .GreaterThanOrEqualTo(0)
            .When(x => x.nro_pago_parcial != 0);

        RuleFor(x => x.legajo)
            .GreaterThan(0)
            .When(x => x.legajo != 0);

        RuleFor(x => x.fecha_transaccion)
            .Must(f => f == null || f.Value > DateTime.MinValue)
            .WithMessage("La fecha de transacción debe ser válida.");

        RuleFor(x => x.periodo)
            .MaximumLength(10)
            .When(x => !string.IsNullOrWhiteSpace(x.periodo));

        RuleFor(x => x.monto_original)
            .GreaterThanOrEqualTo(0)
            .When(x => x.monto_original != 0);

        RuleFor(x => x.nro_plan)
            .GreaterThan(0)
            .When(x => x.nro_plan.HasValue);

        RuleFor(x => x.debe)
            .GreaterThanOrEqualTo(0)
            .When(x => x.debe != 0);

        RuleFor(x => x.haber)
            .GreaterThanOrEqualTo(0)
            .When(x => x.haber != 0);

        RuleFor(x => x.nro_procuracion)
            .GreaterThan(0)
            .When(x => x.nro_procuracion.HasValue);

        RuleFor(x => x.vencimiento)
            .Must(f => f == null || f.Value > DateTime.MinValue)
            .WithMessage("La fecha de vencimiento debe ser válida.");

        RuleFor(x => x.nro_cedulon)
            .GreaterThanOrEqualTo(0)
            .When(x => x.nro_cedulon != 0);

        RuleFor(x => x.cod_cate_deuda)
            .GreaterThanOrEqualTo(0)
            .When(x => x.cod_cate_deuda != 0);

        RuleFor(x => x.monto_pagado)
            .GreaterThanOrEqualTo(0)
            .When(x => x.monto_pagado != 0);

        RuleFor(x => x.recargo)
            .GreaterThanOrEqualTo(0)
            .When(x => x.recargo != 0);

        RuleFor(x => x.honorarios)
            .GreaterThanOrEqualTo(0)
            .When(x => x.honorarios != 0);

        RuleFor(x => x.iva_hons)
            .GreaterThanOrEqualTo(0)
            .When(x => x.iva_hons != 0);

        RuleFor(x => x.decreto)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.decreto));

        RuleFor(x => x.observaciones)
            .MaximumLength(255)
            .When(x => !string.IsNullOrWhiteSpace(x.observaciones));

        RuleFor(x => x.nro_cedulon_paypertic)
            .GreaterThanOrEqualTo(0)
            .When(x => x.nro_cedulon_paypertic != 0);

        RuleFor(x => x.des_movimiento)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.des_movimiento));

        RuleFor(x => x.des_categoria)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.des_categoria));

        RuleFor(x => x.deuda)
            .GreaterThanOrEqualTo(0)
            .When(x => x.deuda != 0);

        RuleFor(x => x.sel)
            .GreaterThanOrEqualTo(0)
            .When(x => x.sel != 0);

        RuleFor(x => x.costo_financiero)
            .GreaterThanOrEqualTo(0)
            .When(x => x.costo_financiero != 0);

        RuleFor(x => x.des_rubro)
            .MaximumLength(100)
            .When(x => !string.IsNullOrWhiteSpace(x.des_rubro));

        RuleFor(x => x.cod_tipo_per)
            .GreaterThanOrEqualTo(0)
            .When(x => x.cod_tipo_per != 0);

        RuleFor(x => x.sub_total)
            .GreaterThanOrEqualTo(0)
            .When(x => x.sub_total != 0);

        RuleFor(x => x.deuda_activa)
            .GreaterThanOrEqualTo(0)
            .When(x => x.deuda_activa != 0);
    }
}
