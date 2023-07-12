using Aperia.CleanArchitecture.Application.Customers.Queries.GetDetails;
using Aperia.CleanArchitecture.Contracts.BankAccounts;
using Aperia.CleanArchitecture.Contracts.Customers;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aperia.CleanArchitecture.Presentation.Controllers
{
    /// <summary>
    /// The Customers Controller
    /// </summary>
    /// <seealso cref="ApiController" />
    [Route("customers")]
    public class CustomersController : ApiController
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly ISender _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public CustomersController(ISender mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Gets the details asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDetailsAsync(Guid id)
        {
            var command = new GetDetailsCommand(id);
            var send = await this._mediator.Send(command);

            return send.Match(customer => Ok(CreateCustomerResponse(customer)), Problem);
        }

        /// <summary>
        /// Creates the customer response.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        private static CustomerResponse CreateCustomerResponse(Customer customer)
        {
            var bankAccounts = customer.BankAccounts?.Select(x => new BankAccountResponse(x.Id, customer.Id, x.AccountType, x.Currency, x.Balance)).ToList();

            return new CustomerResponse(customer.Id, customer.Name, customer.PhoneNumber, bankAccounts);
        }

    }
}