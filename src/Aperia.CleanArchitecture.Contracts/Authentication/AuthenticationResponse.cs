namespace Aperia.CleanArchitecture.Contracts.Authentication;

/// <summary>
/// The Authentication Response
/// </summary>
public record AuthenticationResponse(Guid Id, string Email, string Token);