namespace Lexicom.Concentrate.Blazor.WebAssembly.Amenities;
public interface ILocationChangingManager
{
    public Task<string> GetUrlAsync();
    public Task PreventAsync();
}
