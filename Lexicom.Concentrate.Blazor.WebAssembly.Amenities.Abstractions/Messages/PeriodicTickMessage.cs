namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;

public record class PeriodicTickMessage(ulong Tick, DateTimeOffset UtcNow);