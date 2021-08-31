
using CustomAuthSandbox.Authentication.Basic;

namespace CustomAuthSandbox.Services;

public sealed class MockAuthenticationService : IBasicAuthenticationService
{
    public Task<bool> IsValidUserAsync(string user, string password)
        => Task.FromResult(user.Equals("admin", StringComparison.OrdinalIgnoreCase) && password.Equals("12345"));
}
