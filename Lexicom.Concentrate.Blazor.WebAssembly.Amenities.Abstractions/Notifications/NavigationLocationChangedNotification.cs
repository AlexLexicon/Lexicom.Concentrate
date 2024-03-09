using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Notifications;
public record class NavigationLocationChangedNotification(string Url) : INotification;