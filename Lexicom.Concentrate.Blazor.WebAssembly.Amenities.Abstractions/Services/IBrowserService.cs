using Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;

namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Services;
public interface IBrowserService
{
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    Task OpenNewTabAsync(string url, CancellationToken cancellationToken = default);
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    Task ChangeUrlAsync(string url, CancellationToken cancellationToken = default);
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    Task ExecuteJavaScriptFunctionAsync(string functionName, CancellationToken cancellationToken = default, params object[] args);
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="JavascriptExecutionException"/>
    ValueTask<T> ExecuteJavaScriptFunctionAsync<T>(string functionName, CancellationToken cancellationToken = default, params object[] args);
}