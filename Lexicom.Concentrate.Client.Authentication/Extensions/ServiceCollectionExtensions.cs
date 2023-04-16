using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Client.Authentication.Extensions;
public static class ServiceCollectionExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddLexicomConcentrateClientAuthentication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IAuthenticationTokenStore, AuthenticationTokenStore>();

        return services;
    }
}
