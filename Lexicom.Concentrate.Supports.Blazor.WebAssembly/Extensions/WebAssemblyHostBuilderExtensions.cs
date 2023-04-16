using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Lexicom.Concentrate.Supports.Blazor.WebAssembly.Extensions;
public static class WebAssemblyHostBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static WebAssemblyHostBuilder LexicomConcentrate(this WebAssemblyHostBuilder builder, Action<IConcentrateBlazorWebAssemblyServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        configure?.Invoke(new ConcentrateBlazorWebAssemblyServiceBuilder(builder));

        return builder;
    }
}
