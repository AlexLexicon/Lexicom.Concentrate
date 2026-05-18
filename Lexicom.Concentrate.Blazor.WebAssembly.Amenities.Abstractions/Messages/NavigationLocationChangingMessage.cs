namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Messages;

public record class NavigationLocationChangingMessage(string Url, ILocationChangingManager LocationChangingManager);