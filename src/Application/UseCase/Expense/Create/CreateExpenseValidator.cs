using Communication.Requests.Expense;
using FluentValidation;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseValidator : AbstractValidator<RequestCreateExpenseJson>
{
    public CreateExpenseValidator()
    {
        RuleFor(prop => prop.Title).NotEmpty()
            .WithMessage("Title is required.");
        
        RuleFor(prop => prop.Amount).GreaterThan(decimal.Zero)
            .WithMessage("Amount must be greater than zero.");
        
        RuleFor(prop => prop.MovementAt).LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("MovementAt must be greater than date.");

        RuleFor(prop => prop.PaymentType).IsInEnum()
            .WithMessage("PaymentType is not valid.");
    }
}