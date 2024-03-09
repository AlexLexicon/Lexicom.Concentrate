namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task<string> GetCurrentUrlAsync();
}