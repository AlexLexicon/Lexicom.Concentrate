using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class NavigationLocationChangedNotification(string Url) : INotification;