using Aperia.CleanArchitecture.Domain.Customers.Entities;
using ErrorOr;
using MediatR;

namespace Aperia.CleanArchitecture.Application.Customers.Queries.GetDetails;

/// <summary>
/// The Get Account Details Command
/// </summary>
public record GetDetailsCommand(Guid CustomerId) : IRequest<ErrorOr<Customer>>;