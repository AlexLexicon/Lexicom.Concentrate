namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IPeriodicMessenger
{
    bool IsStarted { get; }
    void Start(TimeSpan period);
}