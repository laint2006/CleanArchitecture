using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

namespace Aperia.CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// The Bank Account Repository
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Persistence.Repositories.Repository{BankAccount}" />
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IBankAccountRepository" />
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public BankAccountRepository(BankSystemDbContext dbContext) 
            : base(dbContext)
        {
        }

    }
}