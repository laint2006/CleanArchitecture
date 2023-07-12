using Aperia.CleanArchitecture.Application.Authentication.Commands.Register;
using Aperia.CleanArchitecture.Application.Authentication.Queries.Login;
using Aperia.CleanArchitecture.Contracts.Authentication;
using Aperia.CleanArchitecture.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aperia.CleanArchitecture.Presentation.Controllers
{
    /// <summary>
    /// The Authentication Controller
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Presentation.Controllers.ApiController" />
    [AllowAnonymous]
    [Route("authentication")]
    public class AuthenticationController : ApiController
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly ISender _mediator;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Email, request.Password);
            var authenticationResult = await _mediator.Send(command);

            return authenticationResult.Match(result => Ok(new AuthenticationResponse(result.User.Id, result.User.Email, result.Token)), Problem);
        }

        /// <summary>
        /// Logins the request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authenticationResult = await _mediator.Send(query);

            if (authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authenticationResult.FirstError.Description);
            }

            return authenticationResult.Match(result => Ok(new AuthenticationResponse(result.User.Id, result.User.Email, result.Token)), Problem);
        }

    }
}