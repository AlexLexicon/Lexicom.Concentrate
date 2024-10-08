﻿using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Models;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
using MediatR;
using Microsoft.JSInterop;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public class TailwindsService : ITailwindsService, IDisposable
{
    private const int TAILWINDS_BREAKPOINT_SIZE_SM = 640;
    private const int TAILWINDS_BREAKPOINT_SIZE_MD = 768;
    private const int TAILWINDS_BREAKPOINT_SIZE_LG = 1024;
    private const int TAILWINDS_BREAKPOINT_SIZE_XL = 1280;
    private const int TAILWINDS_BREAKPOINT_SIZE_2XL = 1536;

    private readonly IMediator _mediator;
    private readonly IBrowserService _browserService;

    public TailwindsService(
        IMediator mediator,
        IBrowserService browserService)
    {
        _mediator = mediator;
        _browserService = browserService;
    }

    private DotNetObjectReference<TailwindsService>? _reference;
    private DotNetObjectReference<TailwindsService> Reference => _reference ??= DotNetObjectReference.Create(this);
    private bool IsInitalized { get; set; }
    private TailwindBreakpoint CurrentBreakpoint { get; set; }

    /// <exception cref="JavascriptExecutionException"/>
    public async Task InitalizeNotificationsAsync(bool invoke = true, bool reset = false, CancellationToken cancellationToken = default)
    {
        if (reset)
        {
            Dispose();
        }

        if (IsInitalized)
        {
            return;
        }

        await _browserService.ExecuteJavaScriptFunctionAsync("window.lexicomConcentrateAmenitiesRegisterTailwindsBreakpointCallback", cancellationToken, Reference);

        IsInitalized = true;

        if (invoke)
        {
            await _browserService.ExecuteJavaScriptFunctionAsync("window.lexicomConcentrateAmenitiesUpdateTailwindsBreakpointCallback", cancellationToken, Reference);
        }
    }

    public Task<TailwindBreakpoint> GetCurrentBreakpointAsync()
    {
        return Task.FromResult(CurrentBreakpoint);
    }

    [JSInvokable]
    public async Task OnJsInvokeAsync(int tailwindsBreakpointSize)
    {
        CurrentBreakpoint = tailwindsBreakpointSize switch
        {
            TAILWINDS_BREAKPOINT_SIZE_2XL => TailwindBreakpoint.B_2xl,
            TAILWINDS_BREAKPOINT_SIZE_XL => TailwindBreakpoint.B_xl,
            TAILWINDS_BREAKPOINT_SIZE_LG => TailwindBreakpoint.B_lg,
            TAILWINDS_BREAKPOINT_SIZE_MD => TailwindBreakpoint.B_md,
            TAILWINDS_BREAKPOINT_SIZE_SM => TailwindBreakpoint.B_sm,
            _ => TailwindBreakpoint.Default,
        };

        await _mediator.Publish(new TailwindsBreakpointChangedNotification(CurrentBreakpoint));
    }

    public void Dispose()
    {
        _reference?.Dispose();
        _reference = null;
        IsInitalized = false;
    }
}
