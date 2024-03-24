using Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Services;
public interface IWikiService
{
    /// <exception cref="ArgumentNullException"/>
    Task<string?> GetUrlFromIdentifierAsync(string urlIdentifier);
    /// <exception cref="ArgumentNullException"/>
    Task<WikiReference?> GetReferenceFromIdentifierAsync(string referenceIdentifier);
}