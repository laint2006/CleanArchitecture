using Aperia.CleanArchitecture.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aperia.CleanArchitecture.Persistence.Configurations
{
    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
            .HasMaxLength(150)
            .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(4000);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        }

    }
}