using Lexicom.Supports.AspNetCore.Controllers;

namespace Lexicom.Concentrate.Supports.AspNetCore.Controllers.Extensions;
public static class AspNetCoreControllersServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IDependentAspNetCoreControllersServiceBuilder Concentrate(this IDependentAspNetCoreControllersServiceBuilder builder, Action<IConcentrateAspNetCoreControllersServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WebApplicationBuilder.LexicomConcentrate(configure);

        return builder;
    }
}
