using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale
/// </summary>
public class CreateSaleItemRequest
{
    public string ItemName { get; set; } = string.Empty;

    public int Quantitie { get; set; }

    public decimal Price { get; set; }

}