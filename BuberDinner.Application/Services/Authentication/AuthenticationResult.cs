using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
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