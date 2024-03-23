namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class PrismService : IPrismService
{
    private readonly IBrowserService _browserService;

    public PrismService(IBrowserService browserService)
    {
        _browserService = browserService;
    }

    public async Task HighlightAllAsync(CancellationToken cancellationToken = default)
    {
        await _browserService.ExecuteJavaScriptFunctionAsync("Prism.highlightAll", cancellationToken);
    }
}
