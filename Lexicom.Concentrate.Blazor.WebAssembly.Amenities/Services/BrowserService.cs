using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class BrowserService : IBrowserService
{
    private readonly IJSRuntime _iJSRuntime;

    /// <exception cref="ArgumentNullException"/>
    public BrowserService(IJSRuntime iJSRuntime)
    {
        ArgumentNullException.ThrowIfNull(iJSRuntime);

        _iJSRuntime = iJSRuntime;
    }

    public async Task OpenNewTabAsync(string url, CancellationToken cancellationToken)
    {
        await _iJSRuntime.InvokeVoidAsync("open", cancellationToken, url, "_blank");
    }

    public async Task ChangeUrlAsync(string url, CancellationToken cancellationToken)
    {
        await _iJSRuntime.InvokeVoidAsync("ChangeUrl", url, cancellationToken);
    }
}
