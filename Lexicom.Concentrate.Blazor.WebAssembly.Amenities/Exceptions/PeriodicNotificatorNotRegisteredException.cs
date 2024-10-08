﻿using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Extensions;
using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
public class PeriodicNotificatorNotRegisteredException() : Exception($"There is no implemented service registration for the interface '{nameof(IPeriodicNotificator)}'. Make sure to call the '{nameof(ConcentrateBlazorWebAssemblyServiceBuilderExtensions)}.{nameof(ConcentrateBlazorWebAssemblyServiceBuilderExtensions.AddAmenities)}()' method.")
{
}
