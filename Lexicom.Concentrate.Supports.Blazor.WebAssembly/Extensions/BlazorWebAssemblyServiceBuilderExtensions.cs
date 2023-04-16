using Lexicom.Supports.Blazor.WebAssembly;

namespace Lexicom.Concentrate.Supports.Blazor.WebAssembly.Extensions;
public static class BlazorWebAssemblyServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IBlazorWebAssemblyServiceBuilder Concentrate(this IBlazorWebAssemblyServiceBuilder builder, Action<IConcentrateBlazorWebAssemblyServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WebAssemblyHostBuilder.LexicomConcentrate(configure);

        return builder;
    }
}
