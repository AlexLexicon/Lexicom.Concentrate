namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IPrismService
{
    Task HighlightAllAsync(CancellationToken cancellationToken = default);
}
