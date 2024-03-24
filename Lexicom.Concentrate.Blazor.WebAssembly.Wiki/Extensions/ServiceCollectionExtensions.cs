using Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Extensions;
public static class ServiceCollectionExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddLexicomConcentrateBlazorWebAssemblyWiki(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IWikiService, WikiService>();

        return services;
    }
}