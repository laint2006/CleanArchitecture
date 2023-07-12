using Aperia.CleanArchitecture.Application.Authentication.Common;
using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Application.Services.Authentication;
using Aperia.CleanArchitecture.Domain.Errors;
using Aperia.CleanArchitecture.Domain.Users.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.Authentication.Commands.Register;

/// <summary>
/// The Register Command Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{RegisterCommand, AuthenticationResult}" />
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    /// <summary>
    /// The JWT token generator
    /// </summary>
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// The user repository
    /// </summary>
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterCommandHandler"/> class.
    /// </summary>
    /// <param name="jwtTokenGenerator">The JWT token generator.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="userRepository">The user repository.</param>
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        this._jwtTokenGenerator = jwtTokenGenerator;
        this._unitOfWork = unitOfWork;
        this._userRepository = userRepository;
    }

    /// <summary>
    /// Handles the command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await this._userRepository.GetUserByEmailAsync(command.Email);
        if (existingUser is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(command.Email, command.Password);

        this._userRepository.Add(user);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);

        var token = this._jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}