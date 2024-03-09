using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Notifications;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class NavigationService : INavigationService, IDisposable
{
    private readonly IMediator _mediator;
    private readonly NavigationManager _navigationManager;

    /// <exception cref="ArgumentNullException"/>
    public NavigationService(
        IMediator mediator,
        NavigationManager navigationManager)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        ArgumentNullException.ThrowIfNull(navigationManager);

        _mediator = mediator;
        _navigationManager = navigationManager;
    }

    public Task InitalizeNotificationsAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _navigationManager.LocationChanged += OnLocationChanged;

        return Task.CompletedTask;
    }

    public Task<string> GetCurrentUrlAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(_navigationManager.Uri);
    }

    public async Task SetUrlAsync(string url, CancellationToken cancellationToken)
    {
        await SetUrlAsync(url, forceLoad: false, cancellationToken);
    }
    public async Task SetUrlAsync(string url, bool forceLoad, CancellationToken cancellationToken)
    {
        await SetUrlAsync(url, forceLoad: false, replace: false, cancellationToken);
    }
    public Task SetUrlAsync(string url, bool forceLoad, bool replace, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _navigationManager.NavigateTo(url, forceLoad, replace);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
    }

    private async void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        await _mediator.Publish(new NavigationLocationChangedNotification(e.Location));
    }
}
