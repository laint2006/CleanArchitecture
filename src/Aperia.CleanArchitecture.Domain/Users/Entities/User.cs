using Aperia.CleanArchitecture.Domain.Common;

namespace Aperia.CleanArchitecture.Domain.Users.Entities
{
    /// <summary>
    /// The User
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Domain.Common.Entity{Guid}" />
    /// <seealso cref="Aperia.CleanArchitecture.Domain.Common.IAuditableEntity" />
    /// <seealso cref="Aperia.CleanArchitecture.Domain.Common.ISoftDeleteEntity" />
    public class User : Entity<Guid>, IAuditableEntity, ISoftDeleteEntity
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        private User(string email, string password)
            : base(Guid.NewGuid())
        {
            this.Email = email;
            this.Password = password;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static User Create(string email, string password)
        {
            var user = new User(email, password);
            user.AddDomainEvent(DomainEvent.Create("User.Created", user));

            return user;
        }


    }
}