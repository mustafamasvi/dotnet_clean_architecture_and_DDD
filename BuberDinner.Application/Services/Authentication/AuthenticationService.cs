using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(LoginReq request)
    {
        if(_userRepository.GetUserByEmail(request.Email) is not User user) 
        {
           return Errors.Authentication.InvalidCredentials;
        }

        if(user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
       return new AuthenticationResult(
        user,
        token);
    }

    public ErrorOr<AuthenticationResult> Register(RegisterReq request)
    {

        if(_userRepository.GetUserByEmail(request.Email) is not null) 
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User{
            FirstName =  request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user, 
        token);
    }
}