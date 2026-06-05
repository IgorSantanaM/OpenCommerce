using OpenCommerce.Domain.Core.Models;

namespace OpenCommerce.Domain.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;


    }
}
