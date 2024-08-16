using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IClipboardService
{
    /// <exception cref="JavascriptExecutionException"/>
    Task<string?> ReadAsync(CancellationToken cancellationToken = default);
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    Task WriteAsync(string text, CancellationToken cancellationToken = default);
}
