using Microsoft.AspNetCore.Components.Routing;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities;
internal class LocationChangingManager : ILocationChangingManager
{
    private readonly LocationChangingContext _locationChangingContext;

    /// <exception cref="ArgumentNullException"/>
    public LocationChangingManager(LocationChangingContext locationChangingContext)
    {
        ArgumentNullException.ThrowIfNull(locationChangingContext);

        _locationChangingContext = locationChangingContext;
    }

    public Task<string> GetUrlAsync()
    {
        return Task.FromResult(_locationChangingContext.TargetLocation);
    }

    public Task PreventAsync()
    {
        _locationChangingContext.PreventNavigation();

        return Task.CompletedTask;
    }
}
