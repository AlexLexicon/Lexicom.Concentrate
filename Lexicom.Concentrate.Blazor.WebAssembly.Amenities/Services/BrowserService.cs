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

        await ExecuteJavaScriptFunctionAsync("open", cancellationToken, url, "_blank");
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task ChangeUrlAsync(string url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(url);

        await ExecuteJavaScriptFunctionAsync("ChangeUrl", cancellationToken, url);
    }

    /// <exception cref="ArgumentNullException"/>
    public async Task ExecuteJavaScriptFunctionAsync(string functionName, CancellationToken cancellationToken = default, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(functionName);

        await _iJSRuntime.InvokeVoidAsync(functionName, cancellationToken, args);
    }

    /// <exception cref="ArgumentNullException"/>
    public async ValueTask<T> ExecuteJavaScriptFunctionAsync<T>(string functionaName, CancellationToken cancellationToken = default, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(functionaName);

        return await _iJSRuntime.InvokeAsync<T>(functionaName, cancellationToken, args);
    }
}
