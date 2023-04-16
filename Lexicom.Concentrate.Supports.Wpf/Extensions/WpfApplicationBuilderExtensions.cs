using Lexicom.Wpf.DependencyInjection;

namespace Lexicom.Concentrate.Supports.Wpf.Extensions;
public static class WpfApplicationBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static WpfApplicationBuilder LexicomConcentrate(this WpfApplicationBuilder builder, Action<IConcentrateWpfServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        configure?.Invoke(new ConcentrateWpfServiceBuilder(builder));

        return builder;
    }
}