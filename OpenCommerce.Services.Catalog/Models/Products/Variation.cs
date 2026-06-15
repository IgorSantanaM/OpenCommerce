using OpenCommerce.Domain.Core.Models;

namespace OpenCommerce.Services.Catalog.Models.Products
{
    public class Variation : Entity<Guid>
    {
        public string SKU { get; private set; }
        /// <summary>
        /// The price of the variation. This can be different from the base product price if the variation has specific attributes that affect its cost (e.g., size, color, material). If the variation does not have a specific price, it can inherit the price from the base product.
        /// </summary>
        public Money? Price { get; private set; } 
        public IReadOnlyDictionary<string, string>? Tags { get; private set; }
        public bool IsBaseVariation { get; set; }

        public Variation(string sku, Money? price, IReadOnlyDictionary<string, string>? tags)
        {
            SKU = sku;
            Price = price;
            Tags = tags ?? new Dictionary<string, string>();
        }
    }
}