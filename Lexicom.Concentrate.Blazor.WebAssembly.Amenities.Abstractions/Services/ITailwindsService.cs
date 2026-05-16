using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Models;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface ITailwindsService
{
    /// <exception cref="JavascriptExecutionException"/>
    Task InitalizeAsync(bool invoke = true, bool reset = false, CancellationToken cancellationToken = default);
    Task<TailwindBreakpoint> GetCurrentBreakpointAsync();
}
