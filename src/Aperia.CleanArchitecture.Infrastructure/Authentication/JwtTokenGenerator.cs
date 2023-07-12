using Aperia.CleanArchitecture.Application.Services;
using Aperia.CleanArchitecture.Application.Services.Authentication;
using Aperia.CleanArchitecture.Domain.Users.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aperia.CleanArchitecture.Infrastructure.Authentication;

/// <summary>
/// The JWT Token Generator
/// </summary>
/// <seealso cref="Aperia.CleanArchitecture.Application.Services.Authentication.IJwtTokenGenerator" />
public class JwtTokenGenerator : IJwtTokenGenerator
{
    /// <summary>
    /// The date time provider
    /// </summary>
    private readonly IDateTimeProvider _dateTimeProvider;

    /// <summary>
    /// The JWT settings
    /// </summary>
    private readonly JwtSettings _jwtSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenGenerator"/> class.
    /// </summary>
    /// <param name="dateTimeProvider">The date time provider.</param>
    /// <param name="jwtOptions">The JWT options.</param>
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    /// <summary>
    /// Generates the token.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns></returns>
    public string GenerateToken(User user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Email.Split('@')[0]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var notBefore = _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);
        var securityToken = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, null, notBefore, signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

}