using Lexicom.Concentrate.Supports.Blazor.WebAssembly;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Extensions;
public static class ConcentrateBlazorWebAssemblyServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IConcentrateBlazorWebAssemblyServiceBuilder AddWiki(this IConcentrateBlazorWebAssemblyServiceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WebAssemblyHostBuilder.Services.AddLexicomConcentrateBlazorWebAssemblyWiki();

        return builder;
    }
}
