using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IPrismService
{
    /// <exception cref="JavascriptExecutionException"/>
    Task HighlightAllAsync(CancellationToken cancellationToken = default);
}
