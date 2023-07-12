namespace Aperia.CleanArchitecture.Contracts.BankAccounts;

/// <summary>
/// The Transfer Request
/// </summary>
public record TransferRequest(Guid ToAccountId, decimal Amount, string? Reference);