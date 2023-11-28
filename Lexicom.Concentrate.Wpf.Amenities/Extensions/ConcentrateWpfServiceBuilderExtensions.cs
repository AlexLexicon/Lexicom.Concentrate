using Lexicom.Concentrate.Supports.Wpf;

namespace Lexicom.Concentrate.Wpf.Amenities.Extensions;
public static class ConcentrateWpfServiceBuilderExtensions
{//test
    /// <exception cref="ArgumentNullException"/>
    public static IConcentrateWpfServiceBuilder AddAmenities(this IConcentrateWpfServiceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WpfApplicationBuilder.Services.AddLexicomConcentrateWpfAmenities();

        return builder;
    }
}
