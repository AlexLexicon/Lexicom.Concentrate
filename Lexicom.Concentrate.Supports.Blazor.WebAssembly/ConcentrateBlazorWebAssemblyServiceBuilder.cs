using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Lexicom.Concentrate.Supports.Blazor.WebAssembly;
public interface IConcentrateBlazorWebAssemblyServiceBuilder
{
    WebAssemblyHostBuilder WebAssemblyHostBuilder { get; }
}
public class ConcentrateBlazorWebAssemblyServiceBuilder : IConcentrateBlazorWebAssemblyServiceBuilder
{
    /// <exception cref="ArgumentNullException"/>
    public ConcentrateBlazorWebAssemblyServiceBuilder(WebAssemblyHostBuilder webAssemblyHostBuilder)
    {
        ArgumentNullException.ThrowIfNull(webAssemblyHostBuilder);

        WebAssemblyHostBuilder = webAssemblyHostBuilder;
    }

    public WebAssemblyHostBuilder WebAssemblyHostBuilder { get; }
}
