using Aperia.CleanArchitecture.Domain.Users.Entities;

namespace Aperia.CleanArchitecture.Application.Repositories;

/// <summary>
/// The IUserRepository interface
/// </summary>
/// <seealso cref="Aperia.CleanArchitecture.Application.Repositories.IRepository{User}" />
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Gets the user by email asynchronous.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns></returns>
    Task<User?> GetUserByEmailAsync(string email);
}