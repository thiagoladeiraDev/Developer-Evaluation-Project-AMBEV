using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<SaleItem> CreateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default)
        {
            await _context.Set<SaleItem>().AddAsync(SaleItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return SaleItem;
        }

        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SaleItem>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<SaleItem?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SaleItem>()
                .FirstOrDefaultAsync(p => p.ItemName == name, cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var SaleItem = await GetByIdAsync(id, cancellationToken);

            if (SaleItem == null)
                return false;

            _context.Set<SaleItem>().Remove(SaleItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
