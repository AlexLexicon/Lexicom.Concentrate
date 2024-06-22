using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface ITailwindsService
{
    Task InitalizeNotificationsAsync(bool invoke = true, bool reset = false, CancellationToken cancellationToken = default);
    Task<TailwindBreakpoint> GetCurrentBreakpointAsync();
}
