using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Models;
using MediatR;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Notifications;
public record class TailwindsBreakpointChangedNotification(TailwindBreakpoint Breakpoint) : INotification;