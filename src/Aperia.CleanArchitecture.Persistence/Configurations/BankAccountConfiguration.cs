using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aperia.CleanArchitecture.Persistence.Configurations
{
    public partial class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> entity)
        {
            entity.ToTable("BankAccount");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AccountType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasConversion<EnumValueConverter<BankAccountType>>();
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Currency)
            .HasMaxLength(10)
            .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.BankAccounts)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BankAccount_Customer");
        }
    }
}