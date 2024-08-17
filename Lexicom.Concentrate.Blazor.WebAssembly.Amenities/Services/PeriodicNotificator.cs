using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using Lexicom.DependencyInjection.Primitives;
using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class PeriodicNotificator : IPeriodicNotificator
{
    private readonly IMediator _mediator;
    private readonly IEnumerable<ITimeProvider> _timeProviderInterfaces;
    private readonly IEnumerable<TimeProvider> _timeProviders;

    public PeriodicNotificator(
        IMediator mediator,
        IEnumerable<ITimeProvider> timeProviderInterfaces,
        IEnumerable<TimeProvider> timeProviders)
    {
        _mediator = mediator;
        _timeProviderInterfaces = timeProviderInterfaces;
        _timeProviders = timeProviders;

        GetUtcNowDelegate = TimeProvider.System.GetUtcNow;
    }

    public bool IsStarted => Timer is not null;

    private Timer? Timer { get; set; }
    private ulong Tick { get; set; }
    private Func<DateTimeOffset> GetUtcNowDelegate { get; set; }

    public void Start(TimeSpan period)
    {
        var timeProviderInterface = _timeProviderInterfaces.FirstOrDefault();
        if (timeProviderInterface is not null)
        {
            GetUtcNowDelegate = timeProviderInterface.GetUtcNow;
        }
        else
        {
            var timeProvider = _timeProviders.FirstOrDefault();
            if (timeProvider is not null)
            {
                GetUtcNowDelegate = timeProvider.GetUtcNow;
            }
        }

        Timer ??= new Timer(TimerCallback, null, TimeSpan.Zero, period);
    }

    private async void TimerCallback(object? thing)
    {
        Tick++;

        DateTimeOffset utcNow = GetUtcNowDelegate.Invoke();
        
        await _mediator.Publish(new PeriodicTickNotification(Tick, utcNow));
    }
}
