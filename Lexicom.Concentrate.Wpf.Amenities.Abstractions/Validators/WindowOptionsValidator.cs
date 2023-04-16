using FluentValidation;
using Lexicom.Validation.Options;

namespace Lexicom.Concentrate.Wpf.Amenities.Validators;
public class WindowOptionsValidator : AbstractOptionsValidator<WindowOptions>
{
    public WindowOptionsValidator()
    {
        //RuleFor(o => o.Left);

        //RuleFor(o => o.Top);

        RuleFor(o => o.Width)
            .GreaterThan(0)
            .Unless(o => o.Width is null);

        RuleFor(o => o.Height)
            .GreaterThan(0)
            .Unless(o => o.Height is null);

        //RuleFor(o => o.IsMaximized);
    }
}
