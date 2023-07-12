using Aperia.CleanArchitecture.Application.Repositories;
using Aperia.CleanArchitecture.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aperia.CleanArchitecture.Persistence.Repositories
{
    /// <summary>
    /// The User Repository
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Persistence.Repositories.Repository{User}" />
    /// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IUserRepository" />
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(BankSystemDbContext dbContext) 
            : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the user by email asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await this.GetQueryable().FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}