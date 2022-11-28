using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(LoginReq request)
    {
        var userId =  Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId,"firstName","LastName");
       return new AuthenticationResult(
        userId,
        "firstname", 
        "lastName", 
        request.Email, 
        token);
    }

    public AuthenticationResult Register(RegisterReq request)
    {
        var userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, request.FirstName, request.LastName);

        return new AuthenticationResult(
        userId, 
        request.FirstName,
        request.LastName,
        request.Email, 
        token);
    }
}