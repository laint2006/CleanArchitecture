using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

namespace Aperia.CleanArchitecture.Contracts.BankAccounts
{
    /// <summary>
    /// The Create Bank Account Request
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Contracts.Request" />
    public class CreateBankAccountRequest : Request
    {
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        public BankAccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public string Currency { get; set; } = null!;

    }
}