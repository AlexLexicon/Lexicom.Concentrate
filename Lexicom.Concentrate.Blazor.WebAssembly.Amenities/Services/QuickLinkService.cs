namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class QuickLinkService : IQuickLinkService
{
    private readonly IEnumerable<IQuickLinksProvider> _quickLinksProviders;
    private readonly IEnumerable<IAsyncQuickLinksProvider> _asyncQuickLinksProviders;

    /// <exception cref="ArgumentNullException"/>
    public QuickLinkService(
        IEnumerable<IQuickLinksProvider> quickLinksProviders,
        IEnumerable<IAsyncQuickLinksProvider> asyncQuickLinksProviders)
    {
        ArgumentNullException.ThrowIfNull(quickLinksProviders);
        ArgumentNullException.ThrowIfNull(asyncQuickLinksProviders);

        _quickLinksProviders = quickLinksProviders;
        _asyncQuickLinksProviders = asyncQuickLinksProviders;
    }

    public Dictionary<string, string>? IdentifierToUrlDictionary { get; set; }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string?> GetUrlFromIdentifierAsync(string identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);

        identifier = identifier.ToLowerInvariant();

        IDictionary<string, string> identifierToLinks = await GetDictionaryOrCreateWhenNotExistingAsync();

        if (identifierToLinks.TryGetValue(identifier, out string? url))
        {
            return url;
        }

        return null;
    }

    private async Task<IDictionary<string, string>> GetDictionaryOrCreateWhenNotExistingAsync()
    {
        if (IdentifierToUrlDictionary is null)
        {
            IdentifierToUrlDictionary = [];

            foreach (IQuickLinksProvider quickLinksProviders in _quickLinksProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = quickLinksProviders.GetIdentifierToUrlDictionary();

                AppendToIdentifierToUrlDictionary(identifierToUrlDictionary);
            }

            foreach (IAsyncQuickLinksProvider asyncQuickLinksProvider in _asyncQuickLinksProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = await asyncQuickLinksProvider.GetIdentifierToUrlDictionaryAsync();

                AppendToIdentifierToUrlDictionary(identifierToUrlDictionary);
            }
        }

        return IdentifierToUrlDictionary;
    }

    private void AppendToIdentifierToUrlDictionary(IDictionary<string, string> identifierToUrlDictionaryToAppend)
    {
        if (IdentifierToUrlDictionary is not null)
        {
            foreach (var identifierToUrl in identifierToUrlDictionaryToAppend)
            {
                if (identifierToUrl.Key is not null && identifierToUrl.Value is not null)
                {
                    string identifier = identifierToUrl.Key.ToLowerInvariant();

                    IdentifierToUrlDictionary.TryAdd(identifier, identifierToUrl.Value);
                }
            }
        }
    }
}
