using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using MediatR;
using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class KeyboardService : IKeyboardService, IDisposable
{
    private readonly IMediator _mediator;
    private readonly IBrowserService _browserService;

    public KeyboardService(
        IMediator mediator,
        IBrowserService browserService)
    {
        _mediator = mediator;
        _browserService = browserService;
    }

    private DotNetObjectReference<KeyboardService>? _reference;
    private DotNetObjectReference<KeyboardService> Reference => _reference ??= DotNetObjectReference.Create(this);
    private bool IsInitalized { get; set; }

    /// <exception cref="JavascriptExecutionException"/>
    public async Task InitalizeNotificationsAsync(bool reset = false, CancellationToken cancellationToken = default)
    {
        if (reset)
        {
            Dispose();
        }

        if (IsInitalized)
        {
            return;
        }

        await _browserService.ExecuteJavaScriptFunctionAsync("window.lexicomConcentrateAmenitiesRegisterKeyboardCallback", cancellationToken, Reference);

        IsInitalized = true;
    }

    [JSInvokable]
    public async Task OnJsInvokeAsync(string key)
    {
        await _mediator.Publish(new KeyboardKeyPressNotification(key));
    }

    public void Dispose()
    {
        _reference?.Dispose();
        _reference = null;
        IsInitalized = false;
    }
}
