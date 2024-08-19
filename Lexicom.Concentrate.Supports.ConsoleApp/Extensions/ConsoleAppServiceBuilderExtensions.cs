using Lexicom.Supports.ConsoleApp;

namespace Lexicom.Concentrate.Supports.ConsoleApp.Extensions;
public static class ConsoleAppServiceBuilderExtensions
{
    public static IDependantConsoleAppServiceBuilder Concentrate(this IDependantConsoleAppServiceBuilder builder, Action<IConcentrateConsoleAppServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ConsoleApplicationBuilder.LexicomConcentrate(configure);

        return builder;
    }
}
