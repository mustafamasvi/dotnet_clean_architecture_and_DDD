using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

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

    public AuthenticationResult Login(LoginReq request)
    {
        if(_userRepository.GetUserByEmail(request.Email) is not User user) 
        {
            throw new Exception("No User with the given email");
        }

        if(user.Password != request.Password)
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
       return new AuthenticationResult(
        user,
        token);
    }

    public AuthenticationResult Register(RegisterReq request)
    {

        if(_userRepository.GetUserByEmail(request.Email) is not null) 
        {
            throw new Exception("User already exists");
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