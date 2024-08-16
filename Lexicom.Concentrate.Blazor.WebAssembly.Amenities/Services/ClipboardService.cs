using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class ClipboardService : IClipboardService
{
    private readonly IBrowserService _browserService;

    /// <exception cref="ArgumentNullException"/>
    public ClipboardService(IBrowserService browserService)
    {
        ArgumentNullException.ThrowIfNull(browserService);

        _browserService = browserService;
    }

    /// <exception cref="JavascriptExecutionException"/>
    public async Task<string?> ReadClipboardAsync(CancellationToken cancellationToken)
    {
        return await _browserService.ExecuteJavaScriptFunctionAsync<string?>("", cancellationToken);
    }

    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    public async Task WriteClipboardAsync(string text, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(text);

        await _browserService.ExecuteJavaScriptFunctionAsync("clipboard.set", cancellationToken, text);
    }
}
