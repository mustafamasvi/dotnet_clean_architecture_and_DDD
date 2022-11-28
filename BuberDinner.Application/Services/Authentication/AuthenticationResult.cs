namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    Guid id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);

public record LoginReq(
    string Email,
    string Password
);

public record RegisterReq(
    string FirstName,
    string LastName,
    string Email,
    string Password
);