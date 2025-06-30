using FluentValidation;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Validators;

public class Sucursal_Con_AuditoriaValidator : AbstractValidator<Sucursal_Con_Auditoria>
{
    public Sucursal_Con_AuditoriaValidator()
    {
        RuleFor(x => x.sucursal).SetValidator(new Sucursales_indycomValidator())
            .When(x => x.sucursal != null);

        RuleFor(x => x.auditoria)
            .SetValidator(new AuditoriaValidator())
            .When(x => x.auditoria != null);
    }
}