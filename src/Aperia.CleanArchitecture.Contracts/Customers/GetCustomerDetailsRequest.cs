namespace Aperia.CleanArchitecture.Contracts.Customers
{
    /// <summary>
    /// The Get Customer Details Request
    /// </summary>
    /// <seealso cref="Aperia.CleanArchitecture.Contracts.Request" />
    public class GetCustomerDetailsRequest : Request
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public Guid CustomerId { get; set; }

    }
}