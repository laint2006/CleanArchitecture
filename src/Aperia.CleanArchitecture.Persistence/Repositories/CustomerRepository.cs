using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// The Customer Repository
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Persistence.Repositories.Repository{Customer}" />
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.ICustomerRepository" />
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CustomerRepository(BankAccountMgmtDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the customer by identifier or name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public async Task<Customer?> GetByNameAsync(string name, string phoneNumber)
        {
            return await this.GetQueryable()
                .Include(x=>x.BankAccounts)
                .FirstOrDefaultAsync(x => x.Name == name && x.PhoneNumber == phoneNumber);
        }
    }
}