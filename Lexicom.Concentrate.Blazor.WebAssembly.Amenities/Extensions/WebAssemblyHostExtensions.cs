using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Extensions;
public static class WebAssemblyHostExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static void UsePeriodicMessenger(this WebAssemblyHost host, TimeSpan period)
    {
        ArgumentNullException.ThrowIfNull(host);

        IPeriodicMessenger? periodicMessenger = host.Services.GetService<IPeriodicMessenger>();

        if (periodicMessenger is null)
        {
            throw new PeriodicMessengerNotRegisteredException();
        }

        if (periodicMessenger.IsStarted)
        {
            throw new PeriodicMessengerAlreadyStartedException();
        }

        periodicMessenger.Start(period);
    }
}
