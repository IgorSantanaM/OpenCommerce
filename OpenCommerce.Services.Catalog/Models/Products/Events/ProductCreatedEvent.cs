using OpenCommerce.Domain.Core.Models;

namespace OpenCommerce.Services.Catalog.Models.Products.Events
{
    public record ProductCreatedEvent(Guid ProductId, string Name,
        string Description,
        Money Price, ProductImage BaseProductImage,
        Variation BaseVariation) : Event<Guid>(ProductId);
}
