namespace Aperia.CleanArchitecture.Contracts.BankAccounts
{
    public class WithdrawalRequest : Request
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
