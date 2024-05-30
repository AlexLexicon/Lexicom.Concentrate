namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
public interface IPeriodicNotificator
{
    bool IsStarted { get; }
    void Start(TimeSpan period);
}