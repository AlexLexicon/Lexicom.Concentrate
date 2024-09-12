using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Extensions;
public static class WebAssemblyHostExtensions
{
    public static void UsePeriodicNotificator(this WebAssemblyHost host, TimeSpan period)
    {
        IPeriodicNotificator? periodicNotificator = host.Services.GetService<IPeriodicNotificator>();

        if (periodicNotificator is null)
        {
            throw new PeriodicNotificatorNotRegisteredException();
        }

        if (periodicNotificator.IsStarted)
        {
            throw new PeriodicNotificatorAlreadyStartedException();
        }

        periodicNotificator.Start(period);
    }
}
