using Lexicom.Concentrate.Supports.Blazor.WebAssembly;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Extensions;
public static class ConcentrateBlazorWebAssemblyServiceBuilderExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IConcentrateBlazorWebAssemblyServiceBuilder AddAmenities(this IConcentrateBlazorWebAssemblyServiceBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.WebAssemblyHostBuilder.Services.AddLexicomConcentrateBlazorWebAssemblyAmenities();

        return builder;
    }
}
