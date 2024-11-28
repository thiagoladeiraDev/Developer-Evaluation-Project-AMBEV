using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementação de IBranchRepository usando Entity Framework Core.
    /// </summary>
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria uma nova Branch no banco de dados.
        /// </summary>
        /// <param name="Branch">A Branch a ser criada.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A Branch criada.</returns>
        public async Task<Branch> CreateAsync(Branch Branch, CancellationToken cancellationToken = default)
        {
            await _context.Branchs.AddAsync(Branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Branch;
        }

        /// <summary>
        /// Recupera uma Branch pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da Branch.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A Branch encontrada ou null se não encontrar.</returns>
        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Branchs
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        /// <summary>
        /// Recupera uma Branch pelo nome.
        /// </summary>
        /// <param name="nome">O nome da Branch.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A Branch encontrada ou null se não encontrar.</returns>
        public async Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Branchs
                .FirstOrDefaultAsync(f => f.BranchName == name, cancellationToken);
        }

        /// <summary>
        /// Exclui uma Branch pelo identificador único.
        /// </summary>
        /// <param name="id">O identificador único da Branch a ser excluída.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>True se a Branch foi excluída, falso se não foi encontrada.</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var Branch = await GetByIdAsync(id, cancellationToken);
            if (Branch == null)
                return false;

            _context.Branchs.Remove(Branch);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
