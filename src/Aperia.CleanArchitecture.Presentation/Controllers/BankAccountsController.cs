using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Create;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Deposit;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Transfer;
using Aperia.CleanArchitecture.Application.BankAccounts.Commands.Withdraw;
using Aperia.CleanArchitecture.Contracts.BankAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

            return result.Match(bankAccount => Ok(new CreateBankAccountResponse
            {
                BankAccountId = bankAccount.Id
            }), Problem);
        }

        /// <summary>
        /// Deposits asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("deposit")]
        public async Task<IActionResult> DepositAsync(DepositRequest request)
        {
            var command = new DepositCommand(request.AccountId, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(new CreateBankAccountResponse
            {
                BankAccountId = bankAccount.Id
            }), Problem);
        }

        /// <summary>
        /// Withdraws asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawAsync(DepositRequest request)
        {
            var command = new WithdrawCommand(request.AccountId, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(new CreateBankAccountResponse
            {
                BankAccountId = bankAccount.Id
            }), Problem);
        }

        /// <summary>
        /// Transfers asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAsync(TransferRequest request)
        {
            var command = new TransferCommand(request.FromAccountId, request.ToAccountId, request.Amount, request.Reference);
            var result = await this._mediator.Send(command);

            return result.Match(bankAccount => Ok(new CreateBankAccountResponse
            {
               // BankAccountId = bankAccount.Length
            }), Problem);
        }

    }
}