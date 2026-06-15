using OpenCommerce.Domain.Core.Models;
using OpenCommerce.Services.Catalog.Models.Products.Enum;

namespace OpenCommerce.Services.Catalog.Models.Products
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetByCategoryAsync(
        Guid categoryId,
        int page,
        int pageSize);
        Task<Product?> GetBySkuAsync(string sku);
        Task<bool> SkuExistsAsync(string sku);
        Task<PagedResult<Product>> GetActiveAsync(
            int page,
            int pageSize);
        Task<PagedResult<Product>> SearchAsync(
            string term,
            int page,
            int pageSize);
        Task<PagedResult<Product>> GetByStatusAsync(
            ProductStatus status,
            int page,
            int pageSize);
        Task<IReadOnlyList<Product>> GetByIdsAsync(
            IEnumerable<Guid> ids);
    }
}
