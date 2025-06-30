using FluentValidation;
using Web_Api_IyC.Entities;
using Web_Api_IyC.Entities.AUDITORIA;

public class INDYCOMValidator : AbstractValidator<INDYCOM>
{
    public INDYCOMValidator()
    {
        When(x => x.legajo != 0, () =>
            RuleFor(x => x.legajo)
            .GreaterThanOrEqualTo(0).WithMessage("legajo debe ser mayor o igual a cero"));

        When(x => x.nro_bad != 0, () =>
            RuleFor(x => x.nro_bad)
            .GreaterThanOrEqualTo(0).WithMessage("nro_bad debe ser mayor o igual a cero"));

        When(x => x.nro_contrib != 0, () =>
            RuleFor(x => x.nro_contrib)
            .GreaterThanOrEqualTo(0).WithMessage("nro_contrib debe ser mayor o igual a cero"));

        When(x => x.cod_calle != 0, () =>
            RuleFor(x => x.cod_calle)
            .GreaterThanOrEqualTo(0).WithMessage("cod_calle debe ser mayor o igual a cero"));

        When(x => x.nro_dom != 0, () =>
            RuleFor(x => x.nro_dom)
            .GreaterThanOrEqualTo(0).WithMessage("nro_dom debe ser mayor o igual a cero"));

        When(x => x.cod_barrio != 0, () =>
            RuleFor(x => x.cod_barrio)
            .GreaterThanOrEqualTo(0).WithMessage("cod_barrio debe ser mayor o igual a cero"));

        When(x => x.cod_tipo_per != 0, () =>
            RuleFor(x => x.cod_tipo_per)
            .GreaterThanOrEqualTo(0).WithMessage("cod_tipo_per debe ser mayor o igual a cero"));

        When(x => x.tipo_liquidacion != 0, () =>
            RuleFor(x => x.tipo_liquidacion)
            .GreaterThanOrEqualTo(0).WithMessage("tipo_liquidacion debe ser mayor o igual a cero"));

        When(x => x.cod_calle_dom_esp != 0, () =>
            RuleFor(x => x.cod_calle_dom_esp)
            .GreaterThanOrEqualTo(0).WithMessage("cod_calle_dom_esp debe ser mayor o igual a cero"));

        When(x => x.nro_dom_esp != 0, () =>
            RuleFor(x => x.nro_dom_esp)
            .GreaterThanOrEqualTo(0).WithMessage("nro_dom_esp debe ser mayor o igual a cero"));

        When(x => x.cod_barrio_dom_esp != 0, () =>
            RuleFor(x => x.cod_barrio_dom_esp)
            .GreaterThanOrEqualTo(0).WithMessage("cod_barrio_dom_esp debe ser mayor o igual a cero"));

        When(x => x.cod_situacion_judicial != 0, () =>
            RuleFor(x => x.cod_situacion_judicial)
            .GreaterThanOrEqualTo(0).WithMessage("cod_situacion_judicial debe ser mayor o igual a cero"));

        When(x => x.nro_sucursal != 0, () =>
            RuleFor(x => x.nro_sucursal)
            .GreaterThanOrEqualTo(0).WithMessage("nro_sucursal debe ser mayor o igual a cero"));

        When(x => x.cod_cond_ante_iva != 0, () =>
            RuleFor(x => x.cod_cond_ante_iva)
            .GreaterThanOrEqualTo(0).WithMessage("cod_cond_ante_iva debe ser mayor o igual a cero"));

        When(x => x.cod_caracter != 0, () =>
            RuleFor(x => x.cod_caracter)
            .GreaterThanOrEqualTo(0).WithMessage("cod_caracter debe ser mayor o igual a cero"));

        When(x => x.des_com != null, () =>
            RuleFor(x => x.des_com)
            .NotEmpty().WithMessage("des_com no puede estar vacío")
            .MaximumLength(40).WithMessage("des_com no puede superar 40 caracteres"));

        When(x => x.nom_fantasia != null, () =>
            RuleFor(x => x.nom_fantasia)
            .NotEmpty().WithMessage("nom_fantasia no puede estar vacío")
            .MaximumLength(40).WithMessage("nom_fantasia no puede superar 40 caracteres"));

        When(x => x.cod_zona != null, () =>
            RuleFor(x => x.cod_zona)
            .NotEmpty().WithMessage("cod_zona no puede estar vacío")
            .MaximumLength(2).WithMessage("cod_zona no puede superar 2 caracteres"));

        When(x => x.pri_periodo != null, () =>
            RuleFor(x => x.pri_periodo)
            .NotEmpty().WithMessage("pri_periodo no puede estar vacío")
            .MaximumLength(7).WithMessage("pri_periodo no puede superar 7 caracteres"));

        When(x => x.per_ult != null, () =>
            RuleFor(x => x.per_ult)
            .NotEmpty().WithMessage("per_ult no puede estar vacío")
            .MaximumLength(7).WithMessage("per_ult no puede superar 7 caracteres"));

        When(x => x.nro_res != null, () =>
            RuleFor(x => x.nro_res)
            .NotEmpty().WithMessage("nro_res no puede estar vacío")
            .MaximumLength(10).WithMessage("nro_res no puede superar 10 caracteres"));

        When(x => x.nro_exp_mesa_ent != null, () =>
            RuleFor(x => x.nro_exp_mesa_ent)
            .NotEmpty().WithMessage("nro_exp_mesa_ent no puede estar vacío")
            .MaximumLength(15).WithMessage("nro_exp_mesa_ent no puede superar 15 caracteres"));

        When(x => x.nro_ing_bruto != null, () =>
            RuleFor(x => x.nro_ing_bruto)
            .NotEmpty().WithMessage("nro_ing_bruto no puede estar vacío")
            .MaximumLength(13).WithMessage("nro_ing_bruto no puede superar 13 caracteres"));

        When(x => x.nro_cuit != null, () =>
            RuleFor(x => x.nro_cuit)
            .NotEmpty().WithMessage("nro_cuit no puede estar vacío")
            .MaximumLength(13).WithMessage("nro_cuit no puede superar 13 caracteres"));

        When(x => x.nom_calle != null, () =>
            RuleFor(x => x.nom_calle)
            .NotEmpty().WithMessage("nom_calle no puede estar vacío")
            .MaximumLength(40).WithMessage("nom_calle no puede superar 40 caracteres"));

        When(x => x.nom_barrio != null, () =>
            RuleFor(x => x.nom_barrio)
            .NotEmpty().WithMessage("nom_barrio no puede estar vacío")
            .MaximumLength(40).WithMessage("nom_barrio no puede superar 40 caracteres"));

        When(x => x.ciudad != null, () =>
            RuleFor(x => x.ciudad)
            .NotEmpty().WithMessage("ciudad no puede estar vacío")
            .MaximumLength(40).WithMessage("ciudad no puede superar 40 caracteres"));

        When(x => x.provincia != null, () =>
            RuleFor(x => x.provincia)
            .NotEmpty().WithMessage("provincia no puede estar vacío")
            .MaximumLength(40).WithMessage("provincia no puede superar 40 caracteres"));

        When(x => x.pais != null, () =>
            RuleFor(x => x.pais)
            .NotEmpty().WithMessage("pais no puede estar vacío")
            .MaximumLength(40).WithMessage("pais no puede superar 40 caracteres"));

        When(x => x.cod_postal != null, () =>
            RuleFor(x => x.cod_postal)
            .NotEmpty().WithMessage("cod_postal no puede estar vacío")
            .MaximumLength(4).WithMessage("cod_postal no puede superar 4 caracteres"));

        When(x => x.nom_calle_dom_esp != null, () =>
            RuleFor(x => x.nom_calle_dom_esp)
            .NotEmpty().WithMessage("nom_calle_dom_esp no puede estar vacío")
            .MaximumLength(40).WithMessage("nom_calle_dom_esp no puede superar 40 caracteres"));

        When(x => x.piso_dpto_esp != null, () =>
            RuleFor(x => x.piso_dpto_esp)
            .NotEmpty().WithMessage("piso_dpto_esp no puede estar vacío")
            .MaximumLength(15).WithMessage("piso_dpto_esp no puede superar 15 caracteres"));

        When(x => x.local_esp != null, () =>
            RuleFor(x => x.local_esp)
            .NotEmpty().WithMessage("local_esp no puede estar vacío")
            .MaximumLength(15).WithMessage("local_esp no puede superar 15 caracteres"));

        When(x => x.nom_barrio_dom_esp != null, () =>
            RuleFor(x => x.nom_barrio_dom_esp)
            .NotEmpty().WithMessage("nom_barrio_dom_esp no puede estar vacío")
            .MaximumLength(40).WithMessage("nom_barrio_dom_esp no puede superar 40 caracteres"));

        When(x => x.ciudad_dom_esp != null, () =>
            RuleFor(x => x.ciudad_dom_esp)
            .NotEmpty().WithMessage("ciudad_dom_esp no puede estar vacío")
            .MaximumLength(40).WithMessage("ciudad_dom_esp no puede superar 40 caracteres"));

        When(x => x.provincia_dom_esp != null, () =>
            RuleFor(x => x.provincia_dom_esp)
            .NotEmpty().WithMessage("provincia_dom_esp no puede estar vacío")
            .MaximumLength(40).WithMessage("provincia_dom_esp no puede superar 40 caracteres"));

        When(x => x.pais_dom_esp != null, () =>
            RuleFor(x => x.pais_dom_esp)
            .NotEmpty().WithMessage("pais_dom_esp no puede estar vacío")
            .MaximumLength(40).WithMessage("pais_dom_esp no puede superar 40 caracteres"));

        When(x => x.cod_postal_dom_esp != null, () =>
            RuleFor(x => x.cod_postal_dom_esp)
            .NotEmpty().WithMessage("cod_postal_dom_esp no puede estar vacío")
            .MaximumLength(4).WithMessage("cod_postal_dom_esp no puede superar 4 caracteres"));

        When(x => x.cod_zona_liquidacion != null, () =>
            RuleFor(x => x.cod_zona_liquidacion)
            .NotEmpty().WithMessage("cod_zona_liquidacion no puede estar vacío")
            .MaximumLength(2).WithMessage("cod_zona_liquidacion no puede superar 2 caracteres"));

        When(x => x.clave_pago != null, () =>
            RuleFor(x => x.clave_pago)
            .NotEmpty().WithMessage("clave_pago no puede estar vacío")
            .MaximumLength(19).WithMessage("clave_pago no puede superar 19 caracteres"));

        When(x => x.email_envio_cedulon != null, () =>
        {
            RuleFor(x => x.email_envio_cedulon)
                .NotEmpty().WithMessage("email_envio_cedulon no puede estar vacío")
                .EmailAddress().WithMessage("email_envio_cedulon debe ser un email válido");
        });

        When(x => x.telefono != null, () =>
            RuleFor(x => x.telefono)
            .NotEmpty().WithMessage("telefono no puede estar vacío")
            .MaximumLength(30).WithMessage("telefono no puede superar 30 caracteres"));

        When(x => x.celular != null, () =>
            RuleFor(x => x.celular)
            .NotEmpty().WithMessage("celular no puede estar vacío")
            .MaximumLength(30).WithMessage("celular no puede superar 30 caracteres"));

        When(x => x.clave_gestion != null, () =>
            RuleFor(x => x.clave_gestion)
            .NotEmpty().WithMessage("clave_gestion no puede estar vacío")
            .MaximumLength(10).WithMessage("clave_gestion no puede superar 10 caracteres"));

        When(x => x.nro_local != null, () =>
            RuleFor(x => x.nro_local)
            .NotEmpty().WithMessage("nro_local no puede estar vacío")
            .MaximumLength(50).WithMessage("nro_local no puede superar 50 caracteres"));

        When(x => x.piso_dpto != null, () =>
            RuleFor(x => x.piso_dpto)
            .NotEmpty().WithMessage("piso_dpto no puede estar vacío")
            .MaximumLength(15).WithMessage("piso_dpto no puede superar 15 caracteres"));

        When(x => x.categoria_iva != null, () =>
            RuleFor(x => x.categoria_iva)
            .NotEmpty().WithMessage("categoria_iva no puede estar vacío")
            .MaximumLength(10).WithMessage("categoria_iva no puede superar 10 caracteres"));

        When(x => x.otra_entidad != null, () =>
            RuleFor(x => x.otra_entidad)
            .NotEmpty().WithMessage("otra_entidad no puede estar vacío")
            .MaximumLength(50).WithMessage("otra_entidad no puede superar 50 caracteres"));

        When(x => x.cod_nueva_zona != null, () =>
            RuleFor(x => x.cod_nueva_zona)
            .NotEmpty().WithMessage("cod_nueva_zona no puede estar vacío")
            .MaximumLength(2).WithMessage("cod_nueva_zona no puede superar 2 caracteres"));

        When(x => x.cuit_vecino_digital != null, () =>
            RuleFor(x => x.cuit_vecino_digital)
            .NotEmpty().WithMessage("cuit_vecino_digital no puede estar vacío")
            .MaximumLength(20).WithMessage("cuit_vecino_digital no puede superar 20 caracteres"));

        When(x => x.titular != null, () =>
            RuleFor(x => x.titular)
            .NotEmpty().WithMessage("titular no puede estar vacío"));

        /*
        When(x => x.objAuditoria != null, () => 
            RuleFor(x => x.objAuditoria).SetValidator(new AuditoriaValidator()));
        */
    }
}
