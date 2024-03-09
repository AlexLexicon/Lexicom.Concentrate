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

    public async Task InitalizeNotificationsAsync(CancellationToken cancellationToken = default)
    {
        _navigationManager.LocationChanged += OnLocationChanged;

        string currentUrl = await GetCurrentUrlAsync();
        await NavigationLocationChangedAsync(currentUrl, cancellationToken);
    }

    public Task<string> GetCurrentUrlAsync()
    {
        return Task.FromResult(_navigationManager.Uri);
    }

    public async Task SetUrlAsync(string url, bool noLoad = false, bool forceLoad = false, bool replace = false, CancellationToken cancellationToken = default)
    {
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
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        await NavigationLocationChangedAsync(e.Location, cancellationToken: default);
    }

    private async Task NavigationLocationChangedAsync(string url, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new NavigationLocationChangedNotification(url), cancellationToken);
    }
}
