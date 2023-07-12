using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// The Repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IRepository{TEntity}" />
    public abstract class Repository<TEntity> : Repository<TEntity, Guid>, IRepository<TEntity>
        where TEntity : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected Repository(BankAccountMgmtDbContext dbContext)
            : base(dbContext)
        {
        }
    }

    /// <summary>
    /// The Repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IRepository{TEntity, TId}" />
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected BankAccountMgmtDbContext DbContext { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected Repository(BankAccountMgmtDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        /// <summary>
        /// Gets all entities asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this.DbContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Gets the entity by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await this.DbContext.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Gets the queryable.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQueryable()
        {
            return this.DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Adds the given entity to the entities set.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(TEntity entity)
        {
            this.DbContext.Set<TEntity>().Remove(entity);
        }
    }

}