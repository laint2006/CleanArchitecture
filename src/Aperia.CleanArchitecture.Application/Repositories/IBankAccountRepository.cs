using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;

namespace Aperia.CleanArchitecture.Application.Repositories
{
    /// <summary>
    /// The IBankAccountRepository interface
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IRepository{BankAccount}" />
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
    }
}