using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Deposit;

/// <summary>
/// The Deposit Command
/// </summary>
public record DepositCommand(Guid AccountId, decimal Amount,  string? Reference) : IRequest<ErrorOr<BankAccount>>;