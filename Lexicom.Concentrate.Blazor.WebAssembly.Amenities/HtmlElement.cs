using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions;
using Microsoft.AspNetCore.Components;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities;
public class HtmlElement : IHtmlElement
{
    public HtmlElement(ElementReference elementReference)
    {
        Id = elementReference.Id;
        Reference = elementReference;
    }

    public string Id { get; }
    public object Reference { get; }
}
