
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace CustomAuthSandbox.Authentication.Basic;

public static class BasicAuthenticationExtensions
{
    public static AuthenticationBuilder AddBasic<TAuthService>(this AuthenticationBuilder builder)
        where TAuthService : class, IBasicAuthenticationService
    {
        return AddBasic<TAuthService>(builder, BasicAuthenticationDefaults.AuthenticationScheme, _ => { });
    }

    public static AuthenticationBuilder AddBasic<TAuthService>(this AuthenticationBuilder builder, string authenticationScheme)
        where TAuthService : class, IBasicAuthenticationService
    {
        return AddBasic<TAuthService>(builder, authenticationScheme, _ => { });
    }

    public static AuthenticationBuilder AddBasic<TAuthService>(this AuthenticationBuilder builder, Action<BasicAuthenticationOptions> configureOptions)
        where TAuthService : class, IBasicAuthenticationService
    {
        return AddBasic<TAuthService>(builder, BasicAuthenticationDefaults.AuthenticationScheme, configureOptions);
    }

    public static AuthenticationBuilder AddBasic<TAuthService>(this AuthenticationBuilder builder, string authenticationScheme, Action<BasicAuthenticationOptions> configureOptions)
        where TAuthService : class, IBasicAuthenticationService
    {
        builder.Services.AddSingleton<IPostConfigureOptions<BasicAuthenticationOptions>, BasicAuthenticationPostConfigureOptions>();
        builder.Services.AddTransient<IBasicAuthenticationService, TAuthService>();

        return builder.AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>(
            authenticationScheme, configureOptions);
    }
}
