using Aperia.CleanArchitecture.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.Authentication.Commands.Register;

public record RegisterCommand(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;