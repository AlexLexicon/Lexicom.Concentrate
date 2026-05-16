using CommunityToolkit.Mvvm.Messaging;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using Lexicom.Mvvm.Extensions;
using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;

public class KeyboardService : IKeyboardService, IDisposable
{
    private readonly IMessenger _messenger;
    private readonly IBrowserService _browserService;

    public KeyboardService(
        IMessenger messenger,
        IBrowserService browserService)
    {
        _messenger = messenger;
        _browserService = browserService;
    }

    private DotNetObjectReference<KeyboardService>? _reference;
    private DotNetObjectReference<KeyboardService> Reference => _reference ??= DotNetObjectReference.Create(this);
    private bool IsInitalized { get; set; }

    /// <exception cref="JavascriptExecutionException"/>
    public async Task InitalizeAsync(bool reset = false, CancellationToken cancellationToken = default)
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
        await _messenger.SendAsync(new KeyboardKeyPressMessage(key));
    }

    public void Dispose()
    {
        _reference?.Dispose();
        _reference = null;
        IsInitalized = false;
    }
}
