namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task InitalizeNotificationsAsync();
    Task<string> GetCurrentUrlAsync();
    Task SetUrlAsync(string url, bool forceLoad = false, bool replace = false);
}