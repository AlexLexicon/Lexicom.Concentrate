﻿using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Abstractions.Services;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Extensions;
public static class ServiceCollectionExtensions
{
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddLexicomConcentrateBlazorWebAssemblyAmenities(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IBrowserService, BrowserService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IPeriodicNotificator, PeriodicNotificator>();
        services.AddSingleton<IPrismService, PrismService>();
        services.AddSingleton<ITailwindsService, TailwindsService>();

        return services;
    }
}
