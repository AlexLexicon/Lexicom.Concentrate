﻿namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IBrowserService
{
    Task OpenNewTabAsync(string url);
}