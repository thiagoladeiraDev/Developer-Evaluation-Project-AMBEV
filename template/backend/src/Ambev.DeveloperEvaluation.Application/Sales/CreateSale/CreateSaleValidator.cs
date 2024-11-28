using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Salename: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        //RuleFor(Sale => Sale.Email).SetValidator(new EmailValidator());
        //RuleFor(Sale => Sale.Salename).NotEmpty().Length(3, 50);
        //RuleFor(Sale => Sale.Password).SetValidator(new PasswordValidator());
        //RuleFor(Sale => Sale.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(Sale => Sale.Status).NotEqual(SaleStatus.Unknown);
        //RuleFor(Sale => Sale.Role).NotEqual(SaleRole.None);
    }
}