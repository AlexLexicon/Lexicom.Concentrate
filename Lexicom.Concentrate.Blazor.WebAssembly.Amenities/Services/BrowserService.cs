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

    /// <exception cref="ArgumentNullException"/>
    public async Task OpenNewTabAsync(string url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(url);

        await ExecuteJavaScriptAsync("open", cancellationToken, url, "_blank");
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task ChangeUrlAsync(string url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(url);

        await ExecuteJavaScriptAsync("ChangeUrl", cancellationToken, url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task ExecuteJavaScriptAsync(string javascript, CancellationToken cancellationToken = default, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(javascript);

        await _iJSRuntime.InvokeVoidAsync(javascript, cancellationToken, args);
    }

    /// <exception cref="ArgumentNullException"/>
    public async ValueTask<T> ExecuteJavaScriptAsync<T>(string javascript, CancellationToken cancellationToken = default, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(javascript);

        return await _iJSRuntime.InvokeAsync<T>(javascript, cancellationToken, args);
    }
}
