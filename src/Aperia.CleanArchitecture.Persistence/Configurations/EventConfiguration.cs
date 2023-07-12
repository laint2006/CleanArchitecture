using Aperia.CleanArchitecture.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aperia.CleanArchitecture.Persistence.Configurations
{
    public partial class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Event");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        }
    }
}