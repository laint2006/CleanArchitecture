using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Withdraw;

/// <summary>
/// The Withdraw Command
/// </summary>
public record WithdrawCommand(Guid AccountId, decimal Amount,  string? Reference) : IRequest<ErrorOr<BankAccount>>;