namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task InitalizeNotificationsAsync(CancellationToken cancellationToken = default);
    Task RefreshAsync();
    Task<string> GetBaseUrlAsync();
    Task<string> GetCurrentUrlAsync();
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetFullUrlAsync(string relativePath);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetRelativePathUrlAsync(string fullUrl);
    /// <exception cref="ArgumentNullException"/>
    Task SetUrlAsync(string url, bool shadow = false, bool forceLoad = false, bool replace = false, CancellationToken cancellationToken = default);
}