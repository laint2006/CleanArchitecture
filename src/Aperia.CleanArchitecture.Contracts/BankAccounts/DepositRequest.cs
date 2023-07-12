namespace Aperia.CleanArchitecture.Contracts.BankAccounts
{
    /// <summary>
    /// The Deposit Request
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Contracts.Request" />
    public class DepositRequest : Request
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        public string? Reference { get; set; }

    }
}