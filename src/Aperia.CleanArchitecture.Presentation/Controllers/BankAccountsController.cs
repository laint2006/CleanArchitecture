using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Create;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Deposit;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Transfer;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Withdraw;
using Aperia.CleanArchitecture.Contracts.BankAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BankAccount = Aperia.CleanArchitecture.Domain.BankAccounts.Entities.BankAccount;

namespace Aperia.CleanArchitecture.Presentation.Controllers
{
    /// <summary>
    /// The Bank Accounts Controller
    /// </summary>
    /// <seealso cref="ApiController" />
    [Route("bank-accounts")]
    public class BankAccountsController : ApiController
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountsController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public BankAccountsController(ISender mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Creates the bank account asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBankAccountAsync(CreateBankAccountRequest request)
        {
            var command = new CreateBankAccountCommand(request.CustomerName, request.PhoneNumber, request.AccountType, request.Currency);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(CreateBankAccountResponse(bankAccount)), Problem);
        }

        /// <summary>
        /// Deposits asynchronous.
        /// </summary>
        /// <param name="id">The account identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/deposit")]
        public async Task<IActionResult> DepositAsync(Guid id, DepositRequest request)
        {
            var command = new DepositCommand(id, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(CreateBankAccountResponse(bankAccount)), Problem);
        }

        /// <summary>
        /// Withdraws asynchronous.
        /// </summary>
        /// <param name="id">The account identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/withdraw")]
        public async Task<IActionResult> WithdrawAsync(Guid id, WithdrawRequest request)
        {
            var command = new WithdrawCommand(id, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(CreateBankAccountResponse(bankAccount)), Problem);
        }

        /// <summary>
        /// Transfers asynchronous.
        /// </summary>
        /// <param name="id">The account identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/transfer")]
        public async Task<IActionResult> TransferAsync(Guid id, TransferRequest request)
        {
            var command = new TransferCommand(id, request.ToAccountId, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(CreateBankAccountResponse(bankAccount)), Problem);
        }

        /// <summary>
        /// Creates the bank account response.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        private static BankAccountResponse CreateBankAccountResponse(BankAccount bankAccount)
        {
            return new BankAccountResponse(bankAccount.Id, bankAccount.CustomerId, bankAccount.AccountType, bankAccount.Currency, bankAccount.Balance);
        }

    }
}