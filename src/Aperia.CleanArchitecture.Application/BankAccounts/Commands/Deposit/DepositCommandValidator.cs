using FluentValidation;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Deposit;

/// <summary>
/// The Deposit Command Validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator{CreateBankAccountCommand}" />
public class DepositCommandValidator : AbstractValidator<DepositCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DepositCommandValidator"/> class.
    /// </summary>
    public DepositCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEqual(Guid.Empty);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}