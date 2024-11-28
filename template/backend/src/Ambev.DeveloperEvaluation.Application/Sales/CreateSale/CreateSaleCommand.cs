using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{

    public string SalesNumber { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; } = DateTime.UtcNow;

    public string BranchNUmber { get; set; } = string.Empty;

    public string CustomerNumber { get; set; } = string.Empty;

    public List<SaleItem> Items { get; set; } = new List<SaleItem>();


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}