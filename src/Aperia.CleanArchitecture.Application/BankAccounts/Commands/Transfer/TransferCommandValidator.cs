using FluentValidation;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Transfer;

/// <summary>
/// The Transfer Command Validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator{CreateBankAccountCommand}" />
public class TransferCommandValidator : AbstractValidator<TransferCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TransferCommandValidator"/> class.
    /// </summary>
    public TransferCommandValidator()
    {
        RuleFor(x => x.FromAccountId).NotEqual(Guid.Empty);
        RuleFor(x => x.ToAccountId).NotEqual(Guid.Empty);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}