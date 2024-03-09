using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
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

    public Task InitalizeNotificationsAsync()
    {
        _navigationManager.LocationChanged += OnLocationChanged;

        return Task.CompletedTask;
    }

    public Task<string> GetCurrentUrlAsync()
    {
        return Task.FromResult(_navigationManager.Uri);
    }

    public Task SetUrlAsync(string url, bool forceLoad = false, bool replace = false)
    {
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
