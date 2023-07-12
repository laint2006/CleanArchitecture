namespace Aperia.CleanArchitecture.Domain.BankAccounts.Entities
{
    /// <summary>
    /// The Bank Account TransactionType
    /// </summary>
    public enum BankAccountType
    {
        /// <summary>
        /// The checking account
        /// </summary>
        CheckingAccount = 1,

        /// <summary>
        /// The savings account
        /// </summary>
        SavingsAccount = 2,

        /// <summary>
        /// The certificate of deposit
        /// </summary>
        CertificateOfDeposit = 3,

    }
}