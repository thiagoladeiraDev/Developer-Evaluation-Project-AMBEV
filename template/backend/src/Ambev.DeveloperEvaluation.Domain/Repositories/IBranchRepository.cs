using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch> CreateAsync(Branch Branch, CancellationToken cancellationToken = default);

        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
