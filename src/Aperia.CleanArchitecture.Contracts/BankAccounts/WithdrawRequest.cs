namespace Aperia.CleanArchitecture.Contracts.BankAccounts;

/// <summary>
/// The Withdraw Request
/// </summary>
public record WithdrawRequest(decimal Amount, string? Reference);