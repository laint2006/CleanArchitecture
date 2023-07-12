using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Create;

/// <summary>
/// The Create Bank Account Command
/// </summary>
public record CreateBankAccountCommand(string CustomerName, string PhoneNumber, BankAccountType AccountType, string Currency) : IRequest<ErrorOr<BankAccount>>;