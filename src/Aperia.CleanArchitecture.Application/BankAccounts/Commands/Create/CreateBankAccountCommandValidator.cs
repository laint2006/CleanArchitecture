using FluentValidation;

namespace Aperia.CleanArchitecture.Application.BankAccounts.Commands.Create;

/// <summary>
/// The Create Bank Account Command Validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator{CreateBankAccountCommand}" />
public class CreateBankAccountCommandValidator : AbstractValidator<CreateBankAccountCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBankAccountCommandValidator"/> class.
    /// </summary>
    public CreateBankAccountCommandValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(8).MaximumLength(15);
    }
}