using OpenCommerce.Domain.Core.Models;

namespace OpenCommerce.Domain.Core.Data
{
    public interface IRepository<TEntity, in TId>
        where TEntity : IAggregateRoot
        where TId : notnull
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    }
}
