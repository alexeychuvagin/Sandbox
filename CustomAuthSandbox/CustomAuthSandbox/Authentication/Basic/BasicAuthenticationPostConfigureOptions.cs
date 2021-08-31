
using Microsoft.Extensions.Options;

namespace CustomAuthSandbox.Authentication.Basic;

public sealed class BasicAuthenticationPostConfigureOptions : IPostConfigureOptions<BasicAuthenticationOptions>
{
    public void PostConfigure(string name, BasicAuthenticationOptions options)
    {
        if (string.IsNullOrEmpty(options.Realm))
        {
            throw new InvalidOperationException("Realm must be provided in options");
        }
    }
}