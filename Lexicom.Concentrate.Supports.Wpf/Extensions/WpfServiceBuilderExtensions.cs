using Lexicom.Supports.Wpf;

namespace Lexicom.Concentrate.Supports.Wpf.Extensions;
public static class WpfServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IDependentWpfServiceBuilder Concentrate(this IDependentWpfServiceBuilder builder, Action<IConcentrateWpfServiceBuilder>? configure)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WpfApplicationBuilder.LexicomConcentrate(configure);

        return builder;
    }
}
