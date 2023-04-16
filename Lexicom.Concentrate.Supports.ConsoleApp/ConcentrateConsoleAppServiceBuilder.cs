using Lexicom.ConsoleApp.DependencyInjection;

namespace Lexicom.Concentrate.Supports.ConsoleApp;
public interface IConcentrateConsoleAppServiceBuilder
{
    ConsoleApplicationBuilder ConsoleApplicationBuilder { get; }
}
public class ConcentrateConsoleAppServiceBuilder : IConcentrateConsoleAppServiceBuilder
{
    /// <exception cref="ArgumentNullException"/>
    public ConcentrateConsoleAppServiceBuilder(ConsoleApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        ConsoleApplicationBuilder = builder;
    }

    public ConsoleApplicationBuilder ConsoleApplicationBuilder { get; }
}
