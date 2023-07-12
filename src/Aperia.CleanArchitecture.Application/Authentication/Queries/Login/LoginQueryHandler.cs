using Aperia.CleanArchitecture.Application.Authentication.Common;
using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Application.Services.Authentication;
using Aperia.CleanArchitecture.Domain.Errors;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.Authentication.Queries.Login;

/// <summary>
/// The Login Query Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{LoginQuery, AuthenticationResult}" />
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    /// <summary>
    /// The JWT token generator
    /// </summary>
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    /// <summary>
    /// The user repository
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginQueryHandler"/> class.
    /// </summary>
    /// <param name="jwtTokenGenerator">The JWT token generator.</param>
    /// <param name="userRepository">The user repository.</param>
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
        this._userRepository = userRepository;
    }

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Response from the request
    /// </returns>
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await this._userRepository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = this._jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}