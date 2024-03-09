using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class BrowserService : IBrowserService
{
    private readonly IJSRuntime _iJSRuntime;

    public BrowserService(IJSRuntime iJSRuntime)
    {
        _iJSRuntime = iJSRuntime;
    }

    public async Task OpenNewTabAsync(string url)
    {
        await _iJSRuntime.InvokeVoidAsync("open", url, "_blank");
    }
}
