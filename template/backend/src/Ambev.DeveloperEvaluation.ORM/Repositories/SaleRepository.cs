using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Sale in the database
        /// </summary>
        /// <param name="Sale">The Sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sale</returns>
        public async Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(Sale, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Sale;
        }

        /// <summary>
        /// Retrieves a Sale by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(v => v.SaleItems) 
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a Sale by its unique number
        /// </summary>
        /// <param name="numeroSale">The unique number of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale if found, null otherwise</returns>
        public async Task<Sale?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .FirstOrDefaultAsync(v => v.SaleNumber == saleNumber, cancellationToken);
        }
 
        /// <summary>
        /// Retrieves all Sales
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of all Sales</returns>
        public async Task<IEnumerable<Sale>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(v => v.SaleItems)
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing Sale in the database
        /// </summary>
        /// <param name="Sale">The Sale with updated information</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated Sale</returns>
        public async Task<Sale> UpdateAsync(Sale Sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(Sale);
            await _context.SaveChangesAsync(cancellationToken);
            return Sale;
        }

        /// <summary>
        /// Deletes a Sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Sale was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var Sale = await GetByIdAsync(id, cancellationToken);

            if (Sale == null)
                return false;

            _context.Sales.Remove(Sale);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
