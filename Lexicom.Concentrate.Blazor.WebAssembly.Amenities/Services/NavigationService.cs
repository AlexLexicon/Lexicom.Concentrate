using Microsoft.AspNetCore.Components;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;

public class NavigationService : INavigationService
{
    private readonly NavigationManager _navigationManager;

    public NavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public Task<string> GetCurrentUrlAsync()
    {
        return Task.FromResult(_navigationManager.Uri);
    }
}
