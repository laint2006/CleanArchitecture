using Aperia.CleanArchitecture.Domain.BankAccounts.Entities;
using Aperia.CleanArchitecture.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aperia.CleanArchitecture.Persistence.Configurations
{
    public partial class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.Reference)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasConversion<EnumValueConverter<TransactionType>>();

            entity.HasOne(d => d.BankAccount).WithMany(p => p.Transactions)
            .HasForeignKey(d => d.BankAccountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Transaction_BankAccount");
        }
    }
}