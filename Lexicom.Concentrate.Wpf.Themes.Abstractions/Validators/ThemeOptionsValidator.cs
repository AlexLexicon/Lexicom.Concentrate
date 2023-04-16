using Lexicom.Validation.Amenities.RuleSets;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.Options;

namespace Lexicom.Concentrate.Wpf.Themes.Validators;
public class ThemeOptionsValidator : AbstractOptionsValidator<ThemeOptions>
{
    /// <exception cref="ArgumentNullException"/>
    public ThemeOptionsValidator(RequiredRuleSet requiredRuleSet)
    {
        ArgumentNullException.ThrowIfNull(requiredRuleSet);

        RuleFor(o => o.AppliedTheme)
            .UseRuleSet(requiredRuleSet);
    }
}
