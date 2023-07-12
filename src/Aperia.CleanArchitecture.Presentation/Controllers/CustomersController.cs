using Aperia.CleanArchitecture.Application.Customers.Queries.GetDetails;
using Aperia.CleanArchitecture.Contracts.Customers;
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
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetDetailsAsync(GetCustomerDetailsRequest request)
        {
            var command = new GetDetailsCommand(request.CustomerId);
            var send = await this._mediator.Send(command);

            return send.Match(bankAccount => Ok(new GetCustomerDetailsResponse
            {
                
            }), Problem);
        }

    }
}