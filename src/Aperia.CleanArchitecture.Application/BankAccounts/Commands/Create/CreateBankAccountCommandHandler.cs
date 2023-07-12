using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Create;

/// <summary>
/// The Create Bank Account Command Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{CreateBankAccountCommand, ErrorOrBankAccount}" />
public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, ErrorOr<BankAccount>>
{
    /// <summary>
    /// The unit of work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// The customer repository
    /// </summary>
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// The bank account repository
    /// </summary>
    private readonly IBankAccountRepository _bankAccountRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBankAccountCommandHandler" /> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work.</param>
    /// <param name="customerRepository">The customer repository.</param>
    /// <param name="bankAccountRepository">The bank account repository.</param>
    public CreateBankAccountCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IBankAccountRepository bankAccountRepository)
    {
        this._unitOfWork = unitOfWork;
        this._customerRepository = customerRepository;
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
    public async Task<ErrorOr<BankAccount>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var customer = await this._customerRepository.GetByNameAsync(request.CustomerName, request.PhoneNumber);
        if (customer is null)
        {
            customer = Customer.Create(request.CustomerName, request.PhoneNumber);

            this._customerRepository.Add(customer);
        }

        var bankAccount = customer.AddBankAccount(request.AccountType, request.Currency);
        if (bankAccount.IsError)
        {
            return bankAccount;
        }

        this._bankAccountRepository.Add(bankAccount.Value);

        await this._unitOfWork.SaveChangesAsync(cancellationToken);

        return bankAccount;
    }
}