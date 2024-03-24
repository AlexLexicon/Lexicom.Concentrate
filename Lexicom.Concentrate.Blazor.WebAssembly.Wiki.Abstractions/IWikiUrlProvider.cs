namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki;
public interface IWikiUrlProvider
{
    IDictionary<string, string> GetIdentifierToUrlDictionary();
}
