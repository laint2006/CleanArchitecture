namespace Aperia.CleanArchitecture.Contracts.BankAccounts
{
    public class TransferRequest : Request
    {
        public Guid ToAccountId { get; set; }
        public Guid FromAccountId { get; set; }
        public decimal Amount { get; set; }

        public string? Reference { get; set; }
    }
}
