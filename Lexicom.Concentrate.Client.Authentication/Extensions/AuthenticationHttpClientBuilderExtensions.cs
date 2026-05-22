using Lexicom.Authentication.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Lexicom.Concentrate.Client.Authentication.Extensions;

public static class AuthenticationHttpClientBuilderExtensions
{
    public static void AuthorizeWithAccessToken(this AuthenticationHttpClientBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Builder.Services.TryAddSingleton<IAuthenticationTokenStore, AuthenticationTokenStore>();

        builder.AuthorizeWithAccessToken<IAuthenticationTokenStore>();
    }

    public static void AutomaticallyRefreshAccessToken<TAccessTokenRefresher>(this AuthenticationHttpClientBuilder builder) where TAccessTokenRefresher : class, IHttpClientAccessTokenRefresher
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Builder.Services.TryAddSingleton<IAuthenticationTokenStore, AuthenticationTokenStore>();

        builder.AutomaticallyRefreshAccessToken<IAuthenticationTokenStore, TAccessTokenRefresher>();
    }
}
