using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Lexicom.Concentrate.Supports.Blazor.WebAssembly;
public interface IConcentrateBlazorWebAssemblyServiceBuilder
{
    WebAssemblyHostBuilder WebAssemblyHostBuilder { get; }
}
public class ConcentrateBlazorWebAssemblyServiceBuilder : IConcentrateBlazorWebAssemblyServiceBuilder
{
    /// <exception cref="ArgumentNullException"/>
    public ConcentrateBlazorWebAssemblyServiceBuilder(WebAssemblyHostBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        WebAssemblyHostBuilder = builder;
    }

    public WebAssemblyHostBuilder WebAssemblyHostBuilder { get; }
}
