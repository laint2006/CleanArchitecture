using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using Aperia.CleanArchitecture.Domain.Events.Entities;
using Aperia.CleanArchitecture.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence
{
    /// <summary>
    /// The Bank Account MGMT Database Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IBankAccountMgmtDbContext" />
    public partial class BankAccountMgmtDbContext : DbContext, IBankAccountMgmtDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountMgmtDbContext"/> class.
        /// </summary>
        /// <remarks>
        /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information and examples.
        /// </remarks>
        public BankAccountMgmtDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountMgmtDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public BankAccountMgmtDbContext(DbContextOptions<BankAccountMgmtDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the bank accounts.
        /// </summary>
        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public virtual DbSet<Event> Events { get; set; } = null!;

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run. However, it will still run when creating a compiled model.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
        /// examples.
        /// </para>
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EventConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}