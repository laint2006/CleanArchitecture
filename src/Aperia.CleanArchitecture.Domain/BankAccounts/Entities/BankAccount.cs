using Aperia.CleanArchitecture.Domain.Customers.Entities;
using Aperia.CleanArchitecture.Domain.Primitives;
using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

/// <summary>
/// The Bank Account
/// </summary>
/// <seealso cref="Entity{Guid}" />
/// <seealso cref="IAuditableEntity" />
public class BankAccount : Entity<Guid>, IAuditableEntity
{
    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the type of the account.
    /// </summary>
    public BankAccountType AccountType { get; set; }

    /// <summary>
    /// Gets or sets the currency.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the balance.
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the updated date.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Gets or sets the customer.
    /// </summary>
    public virtual Customer? Customer { get; set; } = null;

    /// <summary>
    /// Gets the transactions.
    /// </summary>
    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount" /> class.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="accountType">Type of the account.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="balance">The balance.</param>
    private BankAccount(Guid customerId, BankAccountType accountType, string currency, decimal balance)
        : base(Guid.NewGuid())
    {
        this.CustomerId = customerId;
        this.AccountType = accountType;
        this.Currency = currency;
        this.Balance = balance;
    }

    /// <summary>
    /// Creates the specified customer identifier.
    /// </summary>
    /// <param name="customerId">The customer identifier.</param>
    /// <param name="accountType">Type of the account.</param>
    /// <param name="currency">The currency.</param>
    /// <param name="balance">The balance.</param>
    /// <returns></returns>
    public static BankAccount Create(Guid customerId, BankAccountType accountType, string currency, decimal balance)
    {
        var customer = new BankAccount(customerId, accountType, currency, balance);
        customer.AddDomainEvent(DomainEvent.Create("BankAccount.Created", customer));

        return customer;
    }

    /// <summary>
    /// Determines whether this instance can withdraw the specified amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>
    ///   <c>true</c> if this instance can withdraw the specified amount; otherwise, <c>false</c>.
    /// </returns>
    public bool CanWithdraw(decimal amount)
    {
        return this.Balance >= amount;
    }

    /// <summary>
    /// Withdraws the specified amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <param name="reference">The reference.</param>
    /// <returns></returns>
    public ErrorOr<Transaction> Withdraw(decimal amount, string? reference)
    {
        if (!this.CanWithdraw(amount))
        {
            return Errors.Errors.BankAccount.InsufficientFunds;
        }

        var transaction = Transaction.Create(TransactionType.Withdraw, amount, reference, DateTime.Now);

        this.Balance -= amount;
        this.Transactions.Add(transaction);
        this.AddDomainEvent(DomainEvent.Create("BankAccount.Withdraw", this));

        return transaction;
    }

    /// <summary>
    /// Deposits the specified amount.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <param name="reference">The reference.</param>
    /// <returns></returns>
    public ErrorOr<Transaction> Deposit(decimal amount, string? reference)
    {
        var transaction = Transaction.Create(TransactionType.Deposit, amount, reference, DateTime.Now);

        this.Balance += amount;
        this.Transactions.Add(transaction);
        this.AddDomainEvent(DomainEvent.Create("BankAccount.Deposit", this));

        return transaction;
    }

}