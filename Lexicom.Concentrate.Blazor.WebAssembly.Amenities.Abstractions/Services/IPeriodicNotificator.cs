namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IPeriodicNotificator
{
    bool IsStarted { get; }
    void Start(TimeSpan period);
}