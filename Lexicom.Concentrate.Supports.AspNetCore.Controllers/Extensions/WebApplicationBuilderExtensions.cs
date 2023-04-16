using Microsoft.AspNetCore.Builder;

namespace Lexicom.Concentrate.Supports.AspNetCore.Controllers.Extensions;
public static class WebApplicationBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static WebApplicationBuilder LexicomConcentrate(this WebApplicationBuilder builder, Action<IConcentrateAspNetCoreControllersServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        configure?.Invoke(new ConcentrateAspNetCoreControllersServiceBuilder(builder));

        return builder;
    }
}