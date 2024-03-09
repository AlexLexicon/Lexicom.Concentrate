namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task InitalizeNotificationsAsync(CancellationToken cancellationToken);
    Task<string> GetCurrentUrlAsync(CancellationToken cancellationToken);
    Task SetUrlAsync(string url, CancellationToken cancellationToken);
    Task SetUrlAsync(string url, bool forceLoad, CancellationToken cancellationToken);
    Task SetUrlAsync(string url, bool forceLoad, bool replace, CancellationToken cancellationToken);
}