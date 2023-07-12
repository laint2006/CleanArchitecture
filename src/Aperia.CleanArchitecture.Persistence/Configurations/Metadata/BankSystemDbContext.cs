using Aperia.CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence
{
    /// <summary>
    /// The Bank System Database Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IBankAccountMgmtDbContext" />
    public partial class BankAccountMgmtDbContext
    {
        /// <summary>
        /// Called when [model creating partial].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>().ApplyConfigurationsFromAssembly(typeof(BankAccountMgmtDbContext).Assembly);
        }
    }
}