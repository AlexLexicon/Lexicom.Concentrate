using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class NavigationLocationChangingNotification(ILocationChangingManager LocationChangingManager) : INotification;