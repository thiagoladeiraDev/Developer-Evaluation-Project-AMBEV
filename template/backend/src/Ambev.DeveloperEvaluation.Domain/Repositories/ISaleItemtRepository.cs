using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {
        Task<SaleItem> CreateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default);

        Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        
        Task<SaleItem?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
