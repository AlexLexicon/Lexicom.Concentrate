using Lexicom.Concentrate.Wpf.Amenities.Validators;
using Lexicom.DependencyInjection.Amenities.Extensions;
using Lexicom.Validation.Options.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Wpf.Amenities.Extensions;
public static class ServiceCollectionExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddLexicomConcentrateWpfAmenities(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddOptions<WindowOptions>()
            .BindConfiguration()
            .Validate<WindowOptions, WindowOptionsValidator>()
            .ValidateOnStart();

        return services;
    }
}
