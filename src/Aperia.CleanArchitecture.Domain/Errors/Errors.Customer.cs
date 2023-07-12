using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.Errors
{
    public static partial class Errors
    {
        public static class Customer
        {
            public static Error DuplicatePhoneNumber => Error.Conflict("Customer.DuplicatePhoneNumber", "Phone number is already in use.");
        }
    }
}