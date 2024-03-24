using Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki;
public interface IAsyncWikiReferenceProvider
{
    Task<IEnumerable<WikiReference>> GetReferencesAsync();
}