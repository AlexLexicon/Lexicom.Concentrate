using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class NavigationLocationChangingNotification(string Url, ILocationChangingManager LocationChangingManager) : INotification;