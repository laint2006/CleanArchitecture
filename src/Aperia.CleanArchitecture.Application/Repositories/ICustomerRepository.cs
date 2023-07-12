using Aperia.CleanArchitecture.Domain.Customers.Entities;

namespace Aperia.CleanArchitecture.Application.Repositories
{
    /// <summary>
    /// The ICustomerRepository interface
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IRepository{Customer}" />
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Gets the by identifier or name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        Task<Customer?> GetByNameAsync(string name, string phoneNumber);
    }
}