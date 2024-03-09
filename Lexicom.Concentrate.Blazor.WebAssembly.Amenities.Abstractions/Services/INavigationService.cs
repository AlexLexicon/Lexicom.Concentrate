namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface INavigationService
{
    Task InitalizeNotificationsAsync(CancellationToken cancellationToken = default);
    Task RefreshAsync();
    Task<string> GetBaseUrlAsync();
    Task<string> GetCurrentUrlAsync();
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetFullUrlAsync(string relativePath);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetRelativePathUrlAsync(string fullUrl);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, bool value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, bool? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, DateTime value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, DateTime? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, DateOnly value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, DateOnly? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, TimeOnly value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, TimeOnly? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, decimal value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, decimal? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, double value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, double? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, float value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, float? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, Guid value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, Guid? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, int value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, int? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, long value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParameterAsync(string name, long? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrLWithQueryParameterAsync(string name, string? value);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParametersAsync(IReadOnlyDictionary<string, object?> parameters);
    /// <exception cref="ArgumentNullException"/>
    Task<string> GetUrlWithQueryParametersAsync(string url, IReadOnlyDictionary<string, object?> parameters);
    /// <exception cref="ArgumentNullException"/>
    Task SetUrlAsync(string url, bool shadow = false, bool forceLoad = false, bool replace = false, CancellationToken cancellationToken = default);
}