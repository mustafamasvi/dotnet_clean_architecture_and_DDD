namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid id, string Firstname, string LastName);
}