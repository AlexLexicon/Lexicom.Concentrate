namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
public interface IHtmlElementService
{
    Task<bool> HasClass(IHtmlElement htmlElement, string className);
}
