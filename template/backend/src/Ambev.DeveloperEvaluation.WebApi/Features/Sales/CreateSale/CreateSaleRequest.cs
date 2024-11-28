using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale
/// </summary>
public class CreateSaleRequest
{
    public string SalesNumber { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; } = DateTime.UtcNow;

    public string BranchNUmber { get; set; } = string.Empty;

    public string CustomerNumber { get; set; } = string.Empty;

    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    
}