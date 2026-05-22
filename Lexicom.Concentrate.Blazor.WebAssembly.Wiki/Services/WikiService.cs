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

        IdentifierToReferenceCreationSemiphore = new SemaphoreSlim(1, 1);
        IdentifierToUrlCreationSemiphore = new SemaphoreSlim(1, 1);
    }

    private SemaphoreSlim IdentifierToReferenceCreationSemiphore { get; }
    private SemaphoreSlim IdentifierToUrlCreationSemiphore { get; }
    private Dictionary<string, WikiReference>? IdentifierToReferenceDictionary { get; set; }
    private Dictionary<string, string>? IdentifierToUrlDictionary { get; set; }

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
        if (IdentifierToReferenceDictionary is not null)
        {
            return IdentifierToReferenceDictionary;
        }

        await IdentifierToReferenceCreationSemiphore.WaitAsync();
        try
        {
            if (IdentifierToReferenceDictionary is not null)
            {
                return IdentifierToReferenceDictionary;
            }

            var dictionary = new Dictionary<string, WikiReference>();

            foreach (IWikiReferenceProvider wikiReferenceProvider in _wikiReferenceProviders)
            {
                IEnumerable<WikiReference> references = wikiReferenceProvider.GetReferences();

                AppendToReferenceDictionary(dictionary, references);
            }

            foreach (IAsyncWikiReferenceProvider asyncWikiReferenceProvider in _asyncWikiReferenceProviders)
            {
                IEnumerable<WikiReference> references = await asyncWikiReferenceProvider.GetReferencesAsync();

                AppendToReferenceDictionary(dictionary, references);
            }

            IdentifierToReferenceDictionary = dictionary;

            return IdentifierToReferenceDictionary;
        }
        finally
        {
            IdentifierToReferenceCreationSemiphore.Release();
        }
    }

    private async Task<IDictionary<string, string>> GetIdentifierToUrlDictionaryOrCreateWhenNotExistingAsync()
    {
        if (IdentifierToUrlDictionary is not null)
        {
            return IdentifierToUrlDictionary;
        }

        await IdentifierToUrlCreationSemiphore.WaitAsync();
        try
        {
            if (IdentifierToUrlDictionary is not null)
            {
                return IdentifierToUrlDictionary;
            }

            var dictionary = new Dictionary<string, string>();

            foreach (IWikiUrlProvider wikiUrlProvider in _wikiUrlProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = wikiUrlProvider.GetIdentifierToUrlDictionary();

                AppendToUrlDictionary(dictionary, identifierToUrlDictionary);
            }

            foreach (IAsyncWikiUrlProvider asyncWikiUrlProvider in _asyncWikiUrlProviders)
            {
                IDictionary<string, string> identifierToUrlDictionary = await asyncWikiUrlProvider.GetIdentifierToUrlDictionaryAsync();

                AppendToUrlDictionary(dictionary, identifierToUrlDictionary);
            }

            IdentifierToUrlDictionary = dictionary;

            return IdentifierToUrlDictionary;
        }
        finally
        {
            IdentifierToUrlCreationSemiphore.Release();
        }
    }

    private static void AppendToReferenceDictionary(Dictionary<string, WikiReference> target, IEnumerable<WikiReference> referencesToAppend)
    {
        if (referencesToAppend is null)
        {
            return;
        }

        foreach (WikiReference reference in referencesToAppend)
        {
            string identifier = reference.Identifier.ToLowerInvariant();

            target.TryAdd(identifier, reference);
        }
    }

    private static void AppendToUrlDictionary(Dictionary<string, string> target, IDictionary<string, string> identifierToUrlDictionaryToAppend)
    {
        if (identifierToUrlDictionaryToAppend is null)
        {
            return;
        }

        foreach (var identifierToUrl in identifierToUrlDictionaryToAppend)
        {
            if (identifierToUrl.Key is not null && identifierToUrl.Value is not null)
            {
                string identifier = identifierToUrl.Key.ToLowerInvariant();

                target.TryAdd(identifier, identifierToUrl.Value);
            }
        }
    }
}
