using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

namespace Aperia.CleanArchitecture.Contracts.BankAccounts;

/// <summary>
/// The Create Bank Account Request
/// </summary>
public record CreateBankAccountRequest(string CustomerName, string PhoneNumber, BankAccountType AccountType, string Currency);