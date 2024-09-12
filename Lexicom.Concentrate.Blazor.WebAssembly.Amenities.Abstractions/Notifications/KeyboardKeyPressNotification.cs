using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class KeyboardKeyPressNotification(string Key) : INotification;