
namespace CustomAuthSandbox.Authentication.Basic;

public interface IBasicAuthenticationService
{
    Task<bool> IsValidUserAsync(string user, string password);
}
