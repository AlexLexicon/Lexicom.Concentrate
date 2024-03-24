using Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Wiki.Services;
public class WikiService : IWikiService
{
    private readonly IEnumerable<IWikiUrlProvider> _wikiUrlProviders;
    private readonly IEnumerable<IAsyncWikiUrlProvider> _asyncWikiUrlProviders;
    private readonly IEnumerable<IWikiReferenceProvider> _wikiReferenceProviders;
    private readonly IEnumerable<IAsyncWikiReferenceProvider> _asyncWikiReferenceProviders;

    /// <exception cref="ArgumentNullException"/>
    public WikiService(
        IEnumerable<IWikiUrlProvider> wikiUrlProviders,
        IEnumerable<IAsyncWikiUrlProvider> asyncWikiUrlProviders,
        IEnumerable<IWikiReferenceProvider> wikiReferenceProviders,
        IEnumerable<IAsyncWikiReferenceProvider> asyncWikiReferenceProviders)
    {
        ArgumentNullException.ThrowIfNull(wikiUrlProviders);
        ArgumentNullException.ThrowIfNull(asyncWikiUrlProviders);
        ArgumentNullException.ThrowIfNull(wikiReferenceProviders);
        ArgumentNullException.ThrowIfNull(asyncWikiReferenceProviders);

        _wikiUrlProviders = wikiUrlProviders;
        _asyncWikiUrlProviders = asyncWikiUrlProviders;
        _wikiReferenceProviders = wikiReferenceProviders;
        _asyncWikiReferenceProviders = asyncWikiReferenceProviders;
    }

    public Dictionary<string, WikiReference>? IdentifierToReferenceDictionary { get; set; }
    public Dictionary<string, string>? IdentifierToUrlDictionary { get; set; }

    /// <exception cref="ArgumentNullException"/>
    public async Task<WikiReference?> GetReferenceFromIdentifierAsync(string referenceIdentifier)
    {
        ArgumentNullException.ThrowIfNull(referenceIdentifier);

        referenceIdentifier = referenceIdentifier.ToLowerInvariant();

        IDictionary<string, WikiReference> identifierToReferenceDictionary = await GetIdentifierToReferenceDictionaryOrCreateWhenNotExistingAsync();

        if (identifierToReferenceDictionary.TryGetValue(referenceIdentifier, out WikiReference? reference))
        {
            return reference;
        }

        return null;
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string?> GetUrlFromIdentifierAsync(string urlIdentifier)
    {
        ArgumentNullException.ThrowIfNull(urlIdentifier);

        urlIdentifier = urlIdentifier.ToLowerInvariant();

        IDictionary<string, string> identifierToUrlDictionary = await GetIdentifierToUrlDictionaryOrCreateWhenNotExistingAsync();

        if (identifierToUrlDictionary.TryGetValue(urlIdentifier, out string? url))
        {
            return url;
        }

        return null;
    }

    private async Task<IDictionary<string, WikiReference>> GetIdentifierToReferenceDictionaryOrCreateWhenNotExistingAsync()
    {
        if (IdentifierToReferenceDictionary is null)
        {
            IdentifierToReferenceDictionary = [];

            foreach (IWikiReferenceProvider wikiReferenceProvider in _wikiReferenceProviders)
            {
                IEnumerable<WikiReference> references = wikiReferenceProvider.GetReferences();

                AppendToIdentifierToReferenceDictionary(references);
            }

            foreach (IAsyncWikiReferenceProvider asyncWikiReferenceProvider in _asyncWikiReferenceProviders)
            {
                IEnumerable<WikiReference> references = await asyncWikiReferenceProvider.GetReferencesAsync();

                AppendToIdentifierToReferenceDictionary(references);
            }
        }

        return IdentifierToReferenceDictionary;
    }

    private async Task<IDictionary<string, string>> GetIdentifierToUrlDictionaryOrCreateWhenNotExistingAsync()
    {
        if (IdentifierToUrlDictionary is null)
        {
            IdentifierToUrlDictionary = [];

            foreach (IWikiUrlProvider wikiUrlProvider in _wikiUrlProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = wikiUrlProvider.GetIdentifierToUrlDictionary();

                AppendToIdentifierToUrlDictionary(identifierToUrlDictionary);
            }

            foreach (IAsyncWikiUrlProvider asyncWikiUrlProvider in _asyncWikiUrlProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = await asyncWikiUrlProvider.GetIdentifierToUrlDictionaryAsync();

                AppendToIdentifierToUrlDictionary(identifierToUrlDictionary);
            }
        }

        return IdentifierToUrlDictionary;
    }

    private void AppendToIdentifierToReferenceDictionary(IEnumerable<WikiReference> referencesToAppend)
    {
        if (IdentifierToReferenceDictionary is not null && referencesToAppend is not null)
        {
            foreach (WikiReference reference in referencesToAppend)
            {
                if (reference.Identifier is not null && reference.Text is not null && reference.Url is not null)
                {
                    string identifier = reference.Identifier.ToLowerInvariant();

                    IdentifierToReferenceDictionary.TryAdd(identifier, reference);
                }
            }
        }
    }

    private void AppendToIdentifierToUrlDictionary(IDictionary<string, string> identifierToUrlDictionaryToAppend)
    {
        if (IdentifierToUrlDictionary is not null && identifierToUrlDictionaryToAppend is not null)
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
