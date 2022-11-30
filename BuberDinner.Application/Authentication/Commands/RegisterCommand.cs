using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands;

public record RegisterCommand(string FirstName,
                              string LastName,
                              string Email,
                              string Password): IRequest<ErrorOr<AuthenticationResult>>;