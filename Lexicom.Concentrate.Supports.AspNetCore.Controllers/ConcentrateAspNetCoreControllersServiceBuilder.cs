using Microsoft.AspNetCore.Builder;

namespace Lexicom.Concentrate.Supports.AspNetCore.Controllers;
public interface IConcentrateAspNetCoreControllersServiceBuilder
{
    WebApplicationBuilder WebApplicationBuilder { get; }
}
public class ConcentrateAspNetCoreControllersServiceBuilder : IConcentrateAspNetCoreControllersServiceBuilder
{
    /// <exception cref="ArgumentNullException"/>
    public ConcentrateAspNetCoreControllersServiceBuilder(WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        WebApplicationBuilder = builder;
    }

    public WebApplicationBuilder WebApplicationBuilder { get; }
}
