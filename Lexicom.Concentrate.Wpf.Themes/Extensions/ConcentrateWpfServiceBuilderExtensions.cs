using Lexicom.Concentrate.Supports.Wpf;

namespace Lexicom.Concentrate.Wpf.Themes.Extensions;
public static class ConcentrateWpfServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IConcentrateWpfServiceBuilder AddTheming(this IConcentrateWpfServiceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WpfApplicationBuilder.Services.AddLexicomConcentrateWpfTheming();

        return builder;
    }
}
