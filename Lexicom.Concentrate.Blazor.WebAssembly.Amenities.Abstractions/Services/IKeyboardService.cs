namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IKeyboardService
{
    Task InitalizeAsync(bool reset = false, CancellationToken cancellationToken = default);
}
