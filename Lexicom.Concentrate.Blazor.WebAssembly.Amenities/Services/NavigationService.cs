using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class NavigationService : INavigationService, IDisposable
{
    private readonly IMediator _mediator;
    private readonly IBrowserService _browserService;
    private readonly NavigationManager _navigationManager;

    /// <exception cref="ArgumentNullException"/>
    public NavigationService(
        IMediator mediator,
        IBrowserService browserService,
        NavigationManager navigationManager)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(browserService);
        ArgumentNullException.ThrowIfNull(navigationManager);

        _mediator = mediator;
        _browserService = browserService;
        _navigationManager = navigationManager;
    }

    private IDisposable? RegisteredLocationChangingHandler { get; set; }

    public async Task InitalizeNotificationsAsync(CancellationToken cancellationToken = default)
    {
        _navigationManager.LocationChanged += OnLocationChanged;
        RegisteredLocationChangingHandler = _navigationManager.RegisterLocationChangingHandler(OnLocationChanging);

        string currentUrl = await GetCurrentUrlAsync();
        await NavigationLocationChangedAsync(currentUrl, cancellationToken);
    }

    public Task RefreshAsync()
    {
        _navigationManager.Refresh();

        return Task.CompletedTask;
    }

    public Task<string> GetBaseUrlAsync()
    {
        return Task.FromResult(_navigationManager.BaseUri);
    }

    public Task<string> GetCurrentUrlAsync()
    {
        return Task.FromResult(_navigationManager.Uri);
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetFullUrlAsync(string relativePath)
    {
        ArgumentNullException.ThrowIfNull(relativePath);

        var fullUri = _navigationManager.ToAbsoluteUri(relativePath);

        return Task.FromResult(fullUri.ToString());
    }

    /// <exception cref="ArgumentNullException"/>
    public Task<string> GetRelativePathUrlAsync(string fullUrl)
    {
        ArgumentNullException.ThrowIfNull(fullUrl);

        string relativePath = _navigationManager.ToBaseRelativePath(fullUrl);

        return Task.FromResult(relativePath);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task SetUrlAsync(string url, bool noLoad = false, bool forceLoad = false, bool replace = false, CancellationToken cancellationToken = default)
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
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        await NavigationLocationChangedAsync(e.Location, cancellationToken: default);
    }

    private async ValueTask OnLocationChanging(LocationChangingContext locationChangingContext)
    {
        var locationChangingManager = new LocationChangingManager(locationChangingContext);

        string url = await locationChangingManager.GetUrlAsync();

        await _mediator.Publish(new NavigationLocationChangingNotification(url, locationChangingManager));
    }

    private async Task NavigationLocationChangedAsync(string url, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new NavigationLocationChangedNotification(url), cancellationToken);
    }
}
