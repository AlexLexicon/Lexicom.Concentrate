namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
public interface IPrismService
{
    Task HighlightAllAsync(CancellationToken cancellationToken = default);
}
