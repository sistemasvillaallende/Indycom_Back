using FluentValidation;
using Web_Api_IyC.Entities.HELPERS;
using Web_Api_IyC.Validators;

public class CtasCtes_Con_AuditoriaValidator : AbstractValidator<CtasCtes_Con_Auditoria>
{
    public CtasCtes_Con_AuditoriaValidator()
    {
        RuleFor(x => x.legajo)
            .GreaterThan(0)
            .When(x => x.legajo != 0);

        RuleForEach(x => x.lstCtastes)
            .SetValidator(new Ctasctes_indycomValidator())
            .When(x => x.lstCtastes != null && x.lstCtastes.Any());

        RuleFor(x => x.auditoria)
            .SetValidator(new AuditoriaValidator())
            .When(x => x.auditoria != null);
    }
}

