using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class PrismService : IPrismService
{
    private readonly IBrowserService _browserService;

    public PrismService(IBrowserService browserService)
    {
        _browserService = browserService;
    }

    /// <exception cref="JavascriptExecutionException"/>
    public async Task HighlightAllAsync(CancellationToken cancellationToken)
    {
        await _browserService.ExecuteJavaScriptFunctionAsync("Prism.highlightAll", cancellationToken);
    }
}
