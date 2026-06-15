using OpenCommerce.Domain.Core.Exceptions;

namespace OpenCommerce.Services.Catalog.Models.Products
{
    public record Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; }
        public Money(decimal amount, string currency)
        {
            if(Amount < 0) throw new DomainException("Amount cannot be negative");
            Amount = amount;
            Currency = currency;
        }
    }
}