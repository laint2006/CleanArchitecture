using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Application.Services;
using Aperia.CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence
{
    /// <summary>
    /// The Unit Of Work
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IUnitOfWork" />
    internal sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly BankAccountMgmtDbContext _dbContext;

        /// <summary>
        /// The date time provider
        /// </summary>
        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="dateTimeProvider">The date time provider.</param>
        public UnitOfWork(BankAccountMgmtDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            this._dbContext = dbContext;
            this._dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ProcessDomainEvents();
            this.UpdateAuditableEntities();

            return await this._dbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Processes the domain events.
        /// </summary>
        public void ProcessDomainEvents()
        {
            var entitiesWithDomainEvents = this._dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Count > 0)
                .Select(entry => entry.Entity)
                .ToList();

            var domainEvents = entitiesWithDomainEvents
                .SelectMany(entry => entry.DomainEvents)
                .ToList();
            var events = domainEvents.Select(x => Domain.Events.Entities.Event.Create(x.EventType, x.Payload));

            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            this._dbContext.Events.AddRange(events);
        }

        /// <summary>
        /// Updates the auditable entities.
        /// </summary>
        /// <returns></returns>
        private void UpdateAuditableEntities()
        {
            var currentTime = this._dateTimeProvider.Now;

            foreach (var entityEntry in this._dbContext.ChangeTracker.Entries())
            {
                if (entityEntry is { State: EntityState.Deleted, Entity: ISoftDeleteEntity softDeleteEntity })
                {
                    softDeleteEntity.IsDeleted = true;
                    softDeleteEntity.UpdatedDate = this._dateTimeProvider.Now;

                    continue;
                }

                if (entityEntry.Entity is IAuditableEntity auditableEntity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            auditableEntity.CreatedDate = currentTime;
                            break;

                        case EntityState.Modified:
                            auditableEntity.UpdatedDate = currentTime;

                            //if (auditableEntity.CreatedDate == DateTime.MinValue)
                            //{
                            //    auditableEntity.CreatedDate = currentTime;
                            //    entityEntry.State = EntityState.Added;
                            //}

                            break;
                    }
                }
            }
        }

    }
}