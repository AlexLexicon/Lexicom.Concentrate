using Lexicom.Concentrate.Client.Authentication.Extensions;
using Lexicom.Concentrate.Supports.Wpf;

namespace Lexicom.Concentrate.Client.Authentication.For.Wpf.Extensions;
public static class ConcentrateWpfServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IConcentrateWpfServiceBuilder AddClientAuthentication(this IConcentrateWpfServiceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WpfApplicationBuilder.Services.AddLexicomConcentrateClientAuthentication();

        return builder;
    }
}
