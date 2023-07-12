namespace Aperia.CleanArchitecture.Contracts.Authentication;

/// <summary>
/// The Login Request
/// </summary>
public record LoginRequest(string Email, string Password);