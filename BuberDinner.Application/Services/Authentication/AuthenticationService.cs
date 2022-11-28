namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(LoginReq request)
    {
       return new AuthenticationResult(
        Guid.NewGuid(), 
        "firstname", 
        "lastName", 
        request.Email, 
        "token");
    }

    public AuthenticationResult Register(RegisterReq request)
    {
        return new AuthenticationResult(
        Guid.NewGuid(), 
        request.FirstName,
        request.LastName,
        request.Email, 
        "token");
    }
}