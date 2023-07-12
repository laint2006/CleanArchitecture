using FluentValidation;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Withdraw;

/// <summary>
/// The Withdraw Command Validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator{CreateBankAccountCommand}" />
public class WithdrawCommandValidator : AbstractValidator<WithdrawCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WithdrawCommandValidator"/> class.
    /// </summary>
    public WithdrawCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEqual(Guid.Empty);
        RuleFor(x => x.Amount).GreaterThan(0);
    }
}