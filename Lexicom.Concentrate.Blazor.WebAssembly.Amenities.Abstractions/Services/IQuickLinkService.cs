namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IQuickLinkService
{
    /// <exception cref="ArgumentNullException"/>
    Task<string?> GetUrlFromIdentifierAsync(string identifier);
}