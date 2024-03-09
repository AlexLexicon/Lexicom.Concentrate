namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task InitalizeNotificationsAsync(CancellationToken cancellationToken = default);
    Task<string> GetCurrentUrlAsync();
    Task SetUrlAsync(string url, bool shadow = false, bool forceLoad = false, bool replace = false, CancellationToken cancellationToken = default);
}