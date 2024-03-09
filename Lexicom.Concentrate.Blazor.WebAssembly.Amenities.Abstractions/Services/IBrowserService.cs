namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IBrowserService
{
    /// <exception cref="ArgumentNullException"/>
    Task OpenNewTabAsync(string url, CancellationToken cancellationToken);
    /// <exception cref="ArgumentNullException"/>
    Task ChangeUrlAsync(string url, CancellationToken cancellationToken);
    /// <exception cref="ArgumentNullException"/>
    Task ScrollToElementIdAsync(string elementId, CancellationToken cancellationToken);
    /// <exception cref="ArgumentNullException"/>
    Task ExecuteJavaScriptAsync(string javascript, CancellationToken cancellationToken = default, params object[] args);
    /// <exception cref="ArgumentNullException"/>
    ValueTask<T> ExecuteJavaScriptAsync<T>(string javascript, CancellationToken cancellationToken = default, params object[] args);
}