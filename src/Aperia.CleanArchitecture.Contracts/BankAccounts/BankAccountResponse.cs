using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

namespace Aperia.CleanArchitecture.Contracts.BankAccounts;

/// <summary>
/// The Bank Account Response
/// </summary>
public record BankAccountResponse(Guid AccountId, Guid CustomerId, BankAccountType AccountType, string Currency, decimal Balance);