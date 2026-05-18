namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IKeyboardService
{
    Task InitializeAsync(bool reset = false, CancellationToken cancellationToken = default);
}
