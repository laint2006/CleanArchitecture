using Aperia.CleanArchitecture.Domain.Users.Entities;

namespace Aperia.CleanArchitecture.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);