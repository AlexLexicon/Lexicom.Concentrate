using Lexicom.ConsoleApp.DependencyInjection;

namespace Lexicom.Concentrate.Supports.ConsoleApp.Extensions;
public static class ConsoleApplicationBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static ConsoleApplicationBuilder LexicomConcentrate(this ConsoleApplicationBuilder builder, Action<IConcentrateConsoleAppServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        configure?.Invoke(new ConcentrateConsoleAppServiceBuilder(builder));

        return builder;
    }
}