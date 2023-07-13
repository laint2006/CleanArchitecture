using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation("Auth.InvalidCred", "Invalid credentials");
    }
}