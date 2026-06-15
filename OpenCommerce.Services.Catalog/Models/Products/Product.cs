using OpenCommerce.Domain.Core.Exceptions;
using OpenCommerce.Domain.Core.Models;
using OpenCommerce.Services.Catalog.Models.Products.Enum;
using OpenCommerce.Services.Catalog.Models.Products.Events;

namespace OpenCommerce.Services.Catalog.Models.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string SKU { get; private set; }
        public Money Price { get; private set; }
        public Category Category { get; private set; }
        public ProductStatus Status { get; set; }
        public IReadOnlyList<ProductImage> Images { get; set; }
        public IReadOnlyList<Variation> Variations { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Product() { }

        public Product(string name, string description,
            string sku, Money price, Category category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name cannot be null");
            if (string.IsNullOrEmpty(description)) throw new DomainException("Description cannot be null");
            if (string.IsNullOrWhiteSpace(sku)) throw new DomainException("SKU cannot be null");
            if (price.Amount < 0) throw new DomainException("Price cannot be negative");

            Name = name;
            Description = description;
            SKU = sku;
            Price = price;
            Category = category;
            Status = ProductStatus.Draft;
            Images = new List<ProductImage>();
            Variations = new List<Variation>();
        }

        public void PublishProduct()
        {
            if (Images.Count == 0)
                throw new DomainException("Cannot publish product without images");

            Status = ProductStatus.Active;

            var @event = new ProductCreatedEvent(Id, Name,
                Description,
                Price, Images!.First(x => x.IsBaseImage),
                Variations.First(x => x.IsBaseVariation));

            AddDomainEvent(@event);
        }

        public void AddVariation(Variation variation)
        {
            if (variation is null) throw new DomainException("Variation cannot be null");
            if (Variations.Any(v => v.SKU == variation.SKU))
                throw new DomainException($"A variation with SKU {variation.SKU} already exists.");
            var variations = Variations.ToList();
            variations.Add(variation);
            Variations = variations;
        }

        public void RemoveVariation(Variation variation)
        {
            if (variation is null) throw new DomainException("Variation cannot be null");
            var variations = Variations.ToList();
            if (!variations.Remove(variation))
                throw new DomainException("Variation not found in product.");
            Variations = variations;
        }

        public void AddImage(ProductImage image)
        {
            if (image is null) throw new DomainException("Image cannot be null");
            var images = Images.ToList();
            images.Add(image);
            Images = images;
        }

        public void RemoveImage(ProductImage image)
        {
            if (image is null) throw new DomainException("Image cannot be null");
            var images = Images.ToList();
            if (!images.Remove(image))
                throw new DomainException("Image not found in product.");
            Images = images;
        }

        public void UpdatePrice(Money newPrice)
        {
            if (newPrice.Amount < 0) throw new DomainException("Price cannot be negative");
            Price = newPrice;
        }
    }
}
