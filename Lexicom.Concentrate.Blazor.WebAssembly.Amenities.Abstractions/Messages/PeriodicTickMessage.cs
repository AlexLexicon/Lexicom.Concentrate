namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Messages;

public record class PeriodicTickMessage(ulong Tick, DateTimeOffset UtcNow);