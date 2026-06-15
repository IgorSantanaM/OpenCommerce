namespace OpenCommerce.Domain.Core.Models
{
    public class PagedResult<TEntity> where TEntity : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TEntity> Items { get; set; }

        public PagedResult(int pageNumber, int pageSize, int totalCount, IEnumerable<TEntity> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items;
        }
    }
}
