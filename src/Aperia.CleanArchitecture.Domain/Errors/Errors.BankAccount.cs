using ErrorOr;

namespace Aperia.CleanArchitecture.Domain.Errors
{
    public static partial class Errors
    {
        public static class BankAccount
        {
            public static Error InsufficientFunds => Error.Validation("BankAccount.InsufficientFunds", "Insufficient Funds");

            public static Error FailedToDeposit => Error.Validation("BankAccount.FailedToDeposit", "Failed To Deposit");

            public static Error FailedToWithdraw => Error.Validation("BankAccount.FailedToWithdraw", "Failed To Withdraw");

        }
    }
}