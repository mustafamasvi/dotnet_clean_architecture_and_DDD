namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(LoginReq request);
    AuthenticationResult Register(RegisterReq request);
}