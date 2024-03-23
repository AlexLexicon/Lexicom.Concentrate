namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IQuickLinksProvider
{
    IDictionary<string, string> GetIdentifierToUrlDictionary();
}
public interface IAsyncQuickLinksProvider
{
    Task<IDictionary<string, string>> GetIdentifierToUrlDictionaryAsync();
}