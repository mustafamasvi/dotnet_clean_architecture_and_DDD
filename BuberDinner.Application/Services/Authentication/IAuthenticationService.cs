using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(LoginReq request);
    ErrorOr<AuthenticationResult> Register(RegisterReq request);
}