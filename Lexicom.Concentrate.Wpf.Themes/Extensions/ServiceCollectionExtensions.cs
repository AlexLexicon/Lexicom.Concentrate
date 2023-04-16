using Lexicom.Concentrate.Wpf.Themes.Validators;
using Lexicom.DependencyInjection.Extensions;
using Lexicom.Validation.Options.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Wpf.Themes.Extensions;
public static class ServiceCollectionExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddLexicomConcentrateWpfTheming(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddOptions<ThemeOptions>()
            .BindConfiguration()
            .Validate<ThemeOptions, ThemeOptionsValidator>()
            .ValidateOnStart();

        services.AddSingleton<IThemeService, WpfThemeService>();

        return services;
    }
}
