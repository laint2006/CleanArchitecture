using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict("User.DuplicateEmail", "Email is already in use.");
    }
}