using Lexicom.Wpf.DependencyInjection;

namespace Lexicom.Concentrate.Supports.Wpf;
public interface IConcentrateWpfServiceBuilder
{
    WpfApplicationBuilder WpfApplicationBuilder { get; }
}
public class ConcentrateWpfServiceBuilder : IConcentrateWpfServiceBuilder
{
    /// <exception cref="ArgumentNullException"/>
    public ConcentrateWpfServiceBuilder(WpfApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        WpfApplicationBuilder = builder;
    }

    public WpfApplicationBuilder WpfApplicationBuilder { get; }
}
