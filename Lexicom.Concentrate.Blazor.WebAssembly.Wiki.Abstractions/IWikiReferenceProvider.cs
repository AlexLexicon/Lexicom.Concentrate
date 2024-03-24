using Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki;
public interface IWikiReferenceProvider
{
    IEnumerable<WikiReference> GetReferences();
}