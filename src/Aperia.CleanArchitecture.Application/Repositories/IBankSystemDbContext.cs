using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Application.Repositories
{
    /// <summary>
    /// The IBankSystemDbContext interface
    /// </summary>
    public interface IBankSystemDbContext
    {
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the bank accounts.
        /// </summary>
        DbSet<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        DbSet<Transaction> Transactions { get; set; }

    }
}