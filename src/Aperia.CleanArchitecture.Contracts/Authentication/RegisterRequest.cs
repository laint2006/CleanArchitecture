namespace Aperia.CleanArchitecture.Contracts.Authentication;

/// <summary>
/// The Register Request
/// </summary>
public record RegisterRequest(string Email, string Password);