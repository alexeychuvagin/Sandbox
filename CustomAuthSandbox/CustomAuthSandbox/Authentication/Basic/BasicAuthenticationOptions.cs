using Microsoft.AspNetCore.Authentication;

namespace CustomAuthSandbox.Authentication.Basic;

public sealed class BasicAuthenticationOptions : AuthenticationSchemeOptions
{
    public string Realm { get; set; } = string.Empty;
}
