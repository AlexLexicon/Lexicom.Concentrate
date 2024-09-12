namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IKeyboardService
{
    Task InitalizeNotificationsAsync(bool reset = false, CancellationToken cancellationToken = default);
}
