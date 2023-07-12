using Aperia.CleanArchitecture.Contracts.BankAccounts;

namespace Aperia.CleanArchitecture.Contracts.Customers;

/// <summary>
/// The Customer Response
/// </summary>
public record CustomerResponse(Guid Id, string Name, string PhoneNumber, List<BankAccountResponse>? Accounts);