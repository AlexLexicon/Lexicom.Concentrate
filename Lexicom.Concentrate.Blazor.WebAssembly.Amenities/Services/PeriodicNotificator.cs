using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class PeriodicNotificator : IPeriodicNotificator
{
    private readonly IMediator _mediator;

    public PeriodicNotificator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public bool IsStarted => Timer is not null;

    private Timer? Timer { get; set; }
    private ulong Tick { get; set; }

    public void Start(TimeSpan period)
    {
        Timer ??= new Timer(async _ =>
        {
            Tick++;
            await _mediator.Publish(new PeriodicTickNotification(Tick));
        }, null, TimeSpan.Zero, period);
    }
}
