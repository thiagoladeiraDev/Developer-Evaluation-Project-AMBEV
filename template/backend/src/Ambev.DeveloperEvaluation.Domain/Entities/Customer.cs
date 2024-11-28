using System;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a customer in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Customer : BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Telephone { get; set; }

        public DateTime CreatedAt { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
