using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Application.Customers.Queries.GetDetails;

/// <summary>
/// The Get Details Query Handler
/// </summary>
/// <seealso cref="MediatR.IRequestHandler{GetDetailsCommand, ErrorOrBankAccount}" />
public class GetDetailsQueryHandler : IRequestHandler<GetDetailsCommand, ErrorOr<Customer>>
{
    /// <summary>
    /// The customer repository
    /// </summary>
    private readonly ICustomerRepository _customerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDetailsQueryHandler" /> class.
    /// </summary>
    /// <param name="customerRepository">The customer repository.</param>
    public GetDetailsQueryHandler(ICustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    /// <summary>
    /// Handles a request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Response from the request
    /// </returns>
    public async Task<ErrorOr<Customer>> Handle(GetDetailsCommand request, CancellationToken cancellationToken)
    {
        var customer = await this._customerRepository.GetQueryable()
            .Include(x => x.BankAccounts)
            .FirstOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);
        if (customer is null)
        {
            return Error.NotFound();
        }

        return customer;
    }
}