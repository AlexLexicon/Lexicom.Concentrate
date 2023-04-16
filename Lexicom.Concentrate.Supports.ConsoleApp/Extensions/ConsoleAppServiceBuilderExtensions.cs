using Lexicom.Supports.ConsoleApp;

namespace Lexicom.Concentrate.Supports.ConsoleApp.Extensions;
public static class ConsoleAppServiceBuilderExtensions
{
    public static IConsoleAppServiceBuilder Concentrate(this IConsoleAppServiceBuilder builder, Action<IConcentrateConsoleAppServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ConsoleApplicationBuilder.LexicomConcentrate(configure);

        return builder;
    }
}
