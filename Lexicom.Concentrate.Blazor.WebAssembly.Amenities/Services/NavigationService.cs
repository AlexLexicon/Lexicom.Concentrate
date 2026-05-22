using CommunityToolkit.Mvvm.Messaging;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Messages;
using Lexicom.Mvvm.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;

public class NavigationService : INavigationService, IDisposable
{
    private readonly ILogger<NavigationService> _logger;
    private readonly IMessenger _messenger;
    private readonly IBrowserService _browserService;
    private readonly NavigationManager _navigationManager;

    /// <exception cref="ArgumentNullException"/>
    public NavigationService(
        ILogger<NavigationService> logger,
        IMessenger messenger,
        IBrowserService browserService,
        NavigationManager navigationManager)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(messenger);
        ArgumentNullException.ThrowIfNull(browserService);
        ArgumentNullException.ThrowIfNull(navigationManager);

        _logger = logger;
        _messenger = messenger;
        _browserService = browserService;
        _navigationManager = navigationManager;
    }

    private bool IsInitialized { get; set; }

    private IDisposable? RegisteredLocationChangingHandler { get; set; }

    public async Task InitializeAsync(bool invoke = true, bool reset = false, CancellationToken cancellationToken = default)
    {
        if (reset)
        {
            Dispose();
        }

        if (IsInitialized)
        {
            return;
        }

        _navigationManager.LocationChanged += OnLocationChanged;

        RegisteredLocationChangingHandler = _navigationManager.RegisterLocationChangingHandler(OnLocationChanging);

        IsInitialized = true;

        if (invoke)
        {
            string currentUrl = await GetUrlAsync();

            await NavigationLocationChangedAsync(currentUrl, cancellationToken);
        }
    }

    public Task RefreshPageAsync()
    {
        _navigationManager.Refresh();

        return Task.CompletedTask;
    }

    public string GetUrl()
    {
        return _navigationManager.Uri;
    }
    public Task<string> GetUrlAsync()
    {
        string url = GetUrl();

        return Task.FromResult(url);
    }

    public string GetBaseUrl()
    {
        return _navigationManager.BaseUri;
    }
    public Task<string> GetBaseUrlAsync()
    {
        string baseUrl = GetBaseUrl();

        return Task.FromResult(baseUrl);
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetAbsoluteUrlAsync(string relativeUrl)
    {
        ArgumentNullException.ThrowIfNull(relativeUrl);

        Uri absoluteUri = _navigationManager.ToAbsoluteUri(relativeUrl);

        return Task.FromResult(absoluteUri.ToString());
    }

    public async Task<string> GetRelativeUrlPathAsync()
    {
        string url = await GetUrlAsync();

        return await GetRelativeUrlPathAsync(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetRelativeUrlPathAsync(string absoluteUrl)
    {
        ArgumentNullException.ThrowIfNull(absoluteUrl);

        string relativePath = _navigationManager.ToBaseRelativePath(absoluteUrl);

        return Task.FromResult(relativePath);
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, bool value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, bool value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, bool? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, bool? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, DateTime value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, DateTime value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, DateTime? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, DateTime? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, DateOnly value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, DateOnly value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, DateOnly? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, DateOnly? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, TimeOnly value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, TimeOnly value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, TimeOnly? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, TimeOnly? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, decimal value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, decimal value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, decimal? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, decimal? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, double value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, double value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, double? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, double? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, float value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, float value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, float? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, float? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, Guid value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, Guid value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, Guid? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, Guid? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, int value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, int value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, int? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, int? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, long value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, long value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, long? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, long? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParameterAsync(string name, string? value)
    {
        ArgumentNullException.ThrowIfNull(name);

        string url = _navigationManager.GetUriWithQueryParameter(name, value);

        return Task.FromResult(url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task<string> GetUrlWithQueryParameterAsync(string url, string name, string? value)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(name);

        return await GetUrlWithQueryParametersAsync(url, new Dictionary<string, object?>
        {
            { name, value }
        });
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParametersAsync(IReadOnlyDictionary<string, object?> parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);

        string urlWithParameters = _navigationManager.GetUriWithQueryParameters(parameters);

        return Task.FromResult(urlWithParameters);
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetUrlWithQueryParametersAsync(string url, IReadOnlyDictionary<string, object?> parameters)
    {
        ArgumentNullException.ThrowIfNull(url);
        ArgumentNullException.ThrowIfNull(parameters);

        string urlWithParameters = _navigationManager.GetUriWithQueryParameters(url, parameters);

        return Task.FromResult(urlWithParameters);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task NavigateToUrlAsync(string url, CancellationToken cancellationToken = default, bool forceLoad = false, bool noLoad = false, bool replace = false)
    {
        ArgumentNullException.ThrowIfNull(url);

        if (noLoad)
        {
            await _browserService.ChangeUrlAsync(url, cancellationToken);

            await NavigationLocationChangedAsync(url, cancellationToken);
        }
        else
        {
            _navigationManager.NavigateTo(url, forceLoad, replace);
        }
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
        RegisteredLocationChangingHandler?.Dispose();
        RegisteredLocationChangingHandler = null;
        IsInitialized = false;
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs args)
    {
        try
        {
            await NavigationLocationChangedAsync(args.Location, cancellationToken: default);
        }
        catch (Exception e)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(e, "An unexpected error occurred while handling a navigation location change to '{location}'.", args?.Location ?? "null");
            }
        }
    }

    private async ValueTask OnLocationChanging(LocationChangingContext locationChangingContext)
    {
        try
        {
            var locationChangingManager = new LocationChangingManager(locationChangingContext);

            string url = await locationChangingManager.GetUrlAsync();

            await _messenger.SendAsync(new NavigationLocationChangingMessage(url, locationChangingManager));
        }
        catch (Exception e)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(e, "An unexpected error occurred while handling a navigation location changing.");
            }
        }
    }

    private async Task NavigationLocationChangedAsync(string url, CancellationToken cancellationToken)
    {
        await _messenger.SendAsync(new NavigationLocationChangedMessage(url), cancellationToken);
    }
}
