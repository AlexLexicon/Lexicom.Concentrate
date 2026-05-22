using Lexicom.Validation;
using Lexicom.Validation.Amenities.RuleSets;
using Lexicom.Validation.Extensions;

namespace Lexicom.Concentrate.Wpf.Sandbox;

public class NameValidator : AbstractValueValidator<string?>
{
    public NameValidator(NameRuleSet nameRuleSet)
    {
        RuleFor(v => v.Value)
            .UseRuleSet(nameRuleSet);
    }
}
