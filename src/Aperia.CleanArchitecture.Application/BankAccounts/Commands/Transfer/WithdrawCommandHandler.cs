using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.Errors;
using ErrorOr;
using MediatR;
using BankAccount = Aperia.CleanArchitecture.Domain.BankAccounts.Entities.BankAccount;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Transfer;

/// <summary>
/// The Transfer Command Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{CreateBankAccountCommand, ErrorOrBankAccount}" />
public class TransferCommandHandler : IRequestHandler<TransferCommand, ErrorOr<BankAccount>>
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
    /// Initializes a new instance of the <see cref="TransferCommandHandler" /> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="bankAccountRepository">The bank account repository.</param>
    public TransferCommandHandler(IUnitOfWork unitOfWork, IBankAccountRepository bankAccountRepository)
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
    public async Task<ErrorOr<BankAccount>> Handle(TransferCommand request, CancellationToken cancellationToken)
    {
        var fromBankAccount = await this._bankAccountRepository.GetByIdAsync(request.FromAccountId);
        if (fromBankAccount is null)
        {
            return Error.NotFound(description: "Invalid from account");
        }

        var toBankAccount = await this._bankAccountRepository.GetByIdAsync(request.ToAccountId);
        if (toBankAccount is null)
        {
            return Error.NotFound(description: "Invalid to account");
        }

        if (!fromBankAccount.CanWithdraw(request.Amount))
        {
            return Errors.BankAccount.InsufficientFunds;
        }

        var depositTransaction = toBankAccount.Deposit(request.Amount, request.Reference);
        if (depositTransaction.IsError)
        {
            return depositTransaction.Errors;
        }

        var withdrawTransaction = fromBankAccount.Withdraw(request.Amount, request.Reference);
        if (withdrawTransaction.IsError)
        {
            return depositTransaction.Errors;
        }

        this. _bankAccountRepository.Update(toBankAccount);
        this._bankAccountRepository.Update(fromBankAccount);
        await this._unitOfWork.SaveChangesAsync(cancellationToken);

        return fromBankAccount;
    }

}