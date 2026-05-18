using CommunityToolkit.Mvvm.Messaging;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Messages;
using Lexicom.DependencyInjection.Primitives;
using Lexicom.Mvvm.Extensions;
using Microsoft.Extensions.Logging;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;

public class PeriodicMessenger : IPeriodicMessenger
{
    private readonly ILogger<PeriodicMessenger> _logger;
    private readonly IMessenger _messenger;
    private readonly IEnumerable<ITimeProvider> _timeProviderInterfaces;
    private readonly IEnumerable<TimeProvider> _timeProviders;

    /// <exception cref="ArgumentNullException"/>
    public PeriodicMessenger(
        ILogger<PeriodicMessenger> logger,
        IMessenger messenger,
        IEnumerable<ITimeProvider> timeProviderInterfaces,
        IEnumerable<TimeProvider> timeProviders)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(messenger);
        ArgumentNullException.ThrowIfNull(timeProviderInterfaces);
        ArgumentNullException.ThrowIfNull(timeProviders);

        _logger = logger;
        _messenger = messenger;
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

        Timer ??= new Timer(TimerCallback, state: null, TimeSpan.Zero, period);
    }

    private async void TimerCallback(object? state)
    {
        DateTimeOffset? utcNow = null;
        try
        {
            Tick++;

            utcNow = GetUtcNowDelegate.Invoke();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "An unexpected error occurred during the timer callback.");
        }

        if (utcNow is not null)
        {
            try
            {
                await _messenger.SendAsync(new PeriodicTickMessage(Tick, utcNow.Value));
            }
            catch (Exception e)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(e, "An unexpected error occurred during the periodic tick.");
                }
            }
        }
    }
}
