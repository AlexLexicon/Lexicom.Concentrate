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
    private string? AccessToken { get; set; }
    private string? RefreshToken { get; set; }

    public Task<bool> IsAuthenticatedAsync()
    {
        bool hasAccessToken = !string.IsNullOrWhiteSpace(AccessToken);
        bool hasRefreshToken = !string.IsNullOrWhiteSpace(RefreshToken);

        return Task.FromResult(hasAccessToken && hasRefreshToken);
    }

    public Task<string?> GetAccessTokenAsync()
    {
        return Task.FromResult(AccessToken);
    }

    public Task SetAccessTokenAsync(string? accessToken)
    {
        AccessToken = accessToken;

        return Task.CompletedTask;
    }

    public Task<string?> GetRefreshTokenAsync()
    {
        return Task.FromResult(RefreshToken);
    }

    public Task SetRefreshTokenAsync(string? refreshToken)
    {
        RefreshToken = refreshToken;

        return Task.CompletedTask;
    }
}
