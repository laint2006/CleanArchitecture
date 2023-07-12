﻿using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Domain.Common;
using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.Customers.Entities;

/// <summary>
/// The Customer
/// </summary>
/// <seealso cref="Aperia.CleanArchitecture.Domain.Common.Entity{Guid}" />
/// <seealso cref="Aperia.CleanArchitecture.Domain.Common.IAuditableEntity" />
public class Customer : Entity<Guid>, IAuditableEntity
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the updated date.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Gets the bank accounts.
    /// </summary>
    public virtual ICollection<BankAccount> BankAccounts { get; } = new List<BankAccount>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="phoneNumber">The phone number.</param>
    private Customer(string name, string phoneNumber)
        : base(Guid.NewGuid())
    {
        this.Name = name;
        this.PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// Creates the specified customer name.
    /// </summary>
    /// <param name="customerName">Name of the customer.</param>
    /// <param name="phoneNumber">The phone number.</param>
    /// <returns></returns>
    public static Customer Create(string customerName, string phoneNumber)
    {
        var customer = new Customer(customerName, phoneNumber);
        customer.AddDomainEvent(DomainEvent.Create("Customer.Created", customer));

        return customer;
    }

    /// <summary>
    /// Adds the bank account.
    /// </summary>
    /// <param name="accountType">Type of the account.</param>
    /// <param name="currency">The currency.</param>
    /// <returns></returns>
    public ErrorOr<BankAccount> AddBankAccount(BankAccountType accountType, string currency)
    {
        var bankAccount = BankAccount.Create(Id, accountType, currency, 0M);
        this.BankAccounts.Add(bankAccount);

        return bankAccount;
    }

}