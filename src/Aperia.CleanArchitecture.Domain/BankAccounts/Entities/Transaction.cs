using Aperia.CleanArchitecture.Domain.Primitives;

namespace Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

/// <summary>
/// The Transaction
/// </summary>
/// <seealso cref="Entity{Guid}" />
public class Transaction : Entity<Guid>
{
    /// <summary>
    /// Gets or sets the bank account identifier.
    /// </summary>
    public Guid BankAccountId { get; set; }

    /// <summary>
    /// Gets or sets the reference.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// Gets or sets the type of the transaction.
    /// </summary>
    public TransactionType TransactionType { get; set; }

    /// <summary>
    /// Gets or sets the amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the transaction date.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Gets or sets the bank account.
    /// </summary>
    public virtual BankAccount BankAccount { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="Transaction"/> class.
    /// </summary>
    /// <param name="transactionType">Type of the transaction.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="reference">The reference.</param>
    /// <param name="transactionDate">The transaction date.</param>
    private Transaction(TransactionType transactionType, decimal amount, string? reference, DateTime transactionDate)
        : base(Guid.NewGuid())
    {
        this.TransactionType = transactionType;
        this.Amount = amount;
        this.Reference = reference;
        this.TransactionDate = transactionDate;
    }

    /// <summary>
    /// Creates the transaction.
    /// </summary>
    /// <param name="transactionType">Type of the transaction.</param>
    /// <param name="amount">The amount.</param>
    /// <param name="reference">The reference.</param>
    /// <param name="transactionDate">The transaction date.</param>
    /// <returns></returns>
    public static Transaction Create(TransactionType transactionType, decimal amount, string? reference, DateTime transactionDate)
    {
        var transaction = new Transaction(transactionType, amount, reference, transactionDate);

        return transaction;
    }

}