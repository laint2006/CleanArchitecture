using FluentValidation;

namespace Aperia.CleanArchitecture.Application.Customers.Queries.GetDetails;

/// <summary>
/// The Get Details Query Validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator{GetDetailsCommand}" />
public class GetDetailsQueryValidator : AbstractValidator<GetDetailsCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetDetailsQueryValidator"/> class.
    /// </summary>
    public GetDetailsQueryValidator()
    {
        RuleFor(x => x.CustomerId).NotEqual(Guid.Empty);
    }
}