using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Notifications;
public record class KeyboardKeyPressNotification(string Key) : INotification;