namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
public interface IKeyboardService
{
    Task InitalizeNotificationsAsync(bool invoke = true, bool reset = false, CancellationToken cancellationToken = default);
}
