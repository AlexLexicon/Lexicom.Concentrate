namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IBrowserService
{
    /// <exception cref="ArgumentNullException"/>
    Task OpenNewTabAsync(string url, CancellationToken cancellationToken = default);
    /// <exception cref="ArgumentNullException"/>
    Task ChangeUrlAsync(string url, CancellationToken cancellationToken = default);
    /// <exception cref="ArgumentNullException"/>
    Task ExecuteJavaScriptFunctionAsync(string javascript, CancellationToken cancellationToken = default, params object[] args);
    /// <exception cref="ArgumentNullException"/>
    ValueTask<T> ExecuteJavaScriptFunctionAsync<T>(string javascript, CancellationToken cancellationToken = default, params object[] args);
}