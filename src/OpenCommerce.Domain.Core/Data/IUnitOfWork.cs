using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCommerce.Domain.Core.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
