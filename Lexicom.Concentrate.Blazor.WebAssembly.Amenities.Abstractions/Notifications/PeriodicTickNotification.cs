using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class PeriodicTickNotification(ulong Tick, DateTimeOffset UtcNow) : INotification;