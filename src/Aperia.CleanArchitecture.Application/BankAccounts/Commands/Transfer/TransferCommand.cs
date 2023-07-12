using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Transfer;

/// <summary>
/// The Transfer Command
/// </summary>
public record TransferCommand(Guid FromAccountId, Guid ToAccountId, decimal Amount,  string? Reference) : IRequest<ErrorOr<Transaction[]>>;