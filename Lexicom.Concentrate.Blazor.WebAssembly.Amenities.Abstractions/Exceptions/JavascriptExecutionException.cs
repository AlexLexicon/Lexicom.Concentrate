namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities.Exceptions;
public class JavascriptExecutionException : Exception
{
    public JavascriptExecutionException(string? functionName, Exception? innerException, object?[]? args) : base($"Failed to execute the javascript function with the name '{functionName ?? "null"}'.", innerException)
    {
        Args = args;
    }

    public object?[]? Args { get; }
}
