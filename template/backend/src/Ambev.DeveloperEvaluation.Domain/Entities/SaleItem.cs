using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a Sale Item
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    public string ItemName { get; set; } = string.Empty;

    public int Quantitie { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public decimal TotalAmount { get; set; }

    public SaleItem()
    {
        AplicaDescontosPorItem();
        CalculaValorTotalPorItem();
    }
    public void AplicaDescontosPorItem()
    {
        //10% de desconto (4+ items: 10% discount)
        if (Quantitie >= 4 && Quantitie < 10)
        {
            //desconta 10% do preço original
            decimal precoComDesconto = Price * 0.9M;

            //TotalAmount = precoComDesconto * precoComDesconto;
        }

        //20% de desconto (10-20 items: 20% discount)
        if (Quantitie >= 10 && Quantitie <= 20)
        {
            //desconta 20% do preço original
            decimal precoComDesconto = Price * 0.8M;

            //TotalAmount = precoComDesconto * precoComDesconto;
        }
    }

    public void CalculaValorTotalPorItem()
    {
        TotalAmount = (Quantitie * Price);
    }
}