using OpenCommerce.Domain.Core.Models;

namespace OpenCommerce.Services.Catalog.Models.Products
{
    public class ProductImage : Entity<Guid>
    {
        public string Url { get; private set; }
        public bool IsBaseImage { get; private set; }
        public int DisplayOrder { get; private set; }

        public ProductImage(string url, bool isBaseImage, int displayOrder)
        {
            Url = url;
            IsBaseImage = isBaseImage;
            DisplayOrder = displayOrder;
        }
    }
}