using Aperia.CleanArchitecture.Domain.Users.Entities;

namespace Aperia.CleanArchitecture.Application.Services.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}