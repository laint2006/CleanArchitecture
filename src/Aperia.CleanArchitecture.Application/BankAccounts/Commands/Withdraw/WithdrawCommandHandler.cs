using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Withdraw;

/// <summary>
/// The Withdraw Command Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{CreateBankAccountCommand, ErrorOrBankAccount}" />
public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, ErrorOr<BankAccount>>
{
    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// The bank account repository
    /// </summary>
    private readonly IBankAccountRepository _bankAccountRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="WithdrawCommandHandler" /> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="bankAccountRepository">The bank account repository.</param>
    public WithdrawCommandHandler(IUnitOfWork unitOfWork, IBankAccountRepository bankAccountRepository)
    {
        this._unitOfWork = unitOfWork;
        this._bankAccountRepository = bankAccountRepository;
    }

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Response from the request
    /// </returns>
    public async Task<ErrorOr<BankAccount>> Handle(WithdrawCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await this._bankAccountRepository.GetByIdAsync(request.AccountId);
        if (bankAccount is null)
        {
            return Error.NotFound(description: "Invalid account");
        }

        var transaction = bankAccount.Withdraw(request.Amount, request.Reference);
        if (transaction.IsError)
        {
            return bankAccount;
        }

        this. _bankAccountRepository.Update(bankAccount);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);

        return bankAccount;
    }
}