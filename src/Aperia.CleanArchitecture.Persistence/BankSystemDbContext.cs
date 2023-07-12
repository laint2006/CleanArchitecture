using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Domain.Customers.Entities;
using Aperia.CleanArchitecture.Domain.Events.Entities;
using Aperia.CleanArchitecture.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence
{
    public partial class BankSystemDbContext : DbContext, IBankSystemDbContext
    {
        public BankSystemDbContext()
        {
        }

        public BankSystemDbContext(DbContextOptions<BankSystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;

        public virtual DbSet<Customer> Customers { get; set; } = null!;

        public virtual DbSet<Event> Events { get; set; } = null!;

        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

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