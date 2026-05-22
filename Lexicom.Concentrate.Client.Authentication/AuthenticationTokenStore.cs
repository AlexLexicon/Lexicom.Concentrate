using Lexicom.Authentication.Http;

namespace Lexicom.Concentrate.Client.Authentication;
public interface IAuthenticationTokenStore : IHttpClientAccessTokenProvider, IHttpClientRefreshTokenProvider
{
    Task<bool> IsAuthenticatedAsync();
    Task SetAccessTokenAsync(string? accessToken);
    Task SetRefreshTokenAsync(string? refreshToken);
}
public class AuthenticationTokenStore : IAuthenticationTokenStore
{
    public AuthenticationTokenStore()
    {
        Lock = new Lock();
    }

    private Lock Lock { get; }
    private string? AccessToken { get; set; }
    private string? RefreshToken { get; set; }

    public Task<bool> IsAuthenticatedAsync()
    {
        lock (Lock)
        {
            bool hasAccessToken = !string.IsNullOrWhiteSpace(AccessToken);
            bool hasRefreshToken = !string.IsNullOrWhiteSpace(RefreshToken);

            return Task.FromResult(hasAccessToken && hasRefreshToken);
        }
    }

    public Task<string?> GetAccessTokenAsync()
    {
        lock (Lock)
        {
            return Task.FromResult(AccessToken);
        }
    }

    public Task SetAccessTokenAsync(string? accessToken)
    {
        lock (Lock)
        {
            AccessToken = accessToken;
        }

        return Task.CompletedTask;
    }

    public Task<string?> GetRefreshTokenAsync()
    {
        lock (Lock)
        {
            return Task.FromResult(RefreshToken);
        }
    }

    public Task SetRefreshTokenAsync(string? refreshToken)
    {
        lock (Lock)
        {
            RefreshToken = refreshToken;
        }

        return Task.CompletedTask;
    }
}
