using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
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
    /// <exception cref="JavascriptExecutionException"/>
    public async Task OpenNewTabAsync(string url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(url);

        await ExecuteJavaScriptFunctionAsync("open", cancellationToken, url, "_blank");
    }

    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    public async Task ChangeUrlAsync(string url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(url);

        await ExecuteJavaScriptFunctionAsync("ChangeUrl", cancellationToken, url);
    }

    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    public async Task ExecuteJavaScriptFunctionAsync(string functionName, CancellationToken cancellationToken, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(functionName);

        try
        {
            await _iJSRuntime.InvokeVoidAsync(functionName, cancellationToken, args);
        }
        catch (Exception e)
        {
            throw new JavascriptExecutionException(functionName, e, args);
        }
    }

    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    public async ValueTask<T> ExecuteJavaScriptFunctionAsync<T>(string functionName, CancellationToken cancellationToken, params object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(functionName);

        try
        {
            return await _iJSRuntime.InvokeAsync<T>(functionName, cancellationToken, args);
        }
        catch (Exception e)
        {
            throw new JavascriptExecutionException(functionName, e, args);
        }
    }
}
