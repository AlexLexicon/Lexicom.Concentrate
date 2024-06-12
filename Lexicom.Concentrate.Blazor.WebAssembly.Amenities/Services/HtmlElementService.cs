using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class HtmlElementService : IHtmlElementService
{
    private readonly IJSRuntime _iJSRuntime;

    public HtmlElementService(IJSRuntime iJSRuntime)
    {
        _iJSRuntime = iJSRuntime;
    }

    public async Task<bool> HasClass(IHtmlElement htmlElement, string className)
    {
        ArgumentNullException.ThrowIfNull(className);

        return await _iJSRuntime.InvokeAsync<bool>("LexicomConcentrateAmenities.hasClass", new
        {
            htmlElement.Reference,
            className,
        });
    }
}
