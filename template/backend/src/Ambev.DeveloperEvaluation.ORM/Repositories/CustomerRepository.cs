﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ICustomerRepository using Entity Framework Core
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of CustomerRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public CustomerRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Customer in the database
        /// </summary>
        /// <param name="Customer">The Customer to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Customer</returns>
        public async Task<Customer> CreateAsync(Customer Customer, CancellationToken cancellationToken = default)
        {
            if (Customer == null)
                throw new ArgumentNullException(nameof(Customer));

            await _context.Customers.AddAsync(Customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Customer;
        }

        /// <summary>
        /// Retrieves a Customer by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Customer</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Customer if found, null otherwise</returns>
        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid Customer ID.", nameof(id));

            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        /// <summary>
        /// Deletes a Customer from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Customer to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Customer was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid Customer ID.", nameof(id));

            var Customer = await GetByIdAsync(id, cancellationToken);
            if (Customer == null)
                return false;

            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
