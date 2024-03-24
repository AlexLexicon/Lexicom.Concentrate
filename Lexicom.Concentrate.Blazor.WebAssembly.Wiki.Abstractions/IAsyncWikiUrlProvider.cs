namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki;
public interface IAsyncWikiUrlProvider
{
    Task<IDictionary<string, string>> GetIdentifierToUrlDictionaryAsync();
}
