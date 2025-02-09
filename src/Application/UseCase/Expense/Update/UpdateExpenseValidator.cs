using Communication.Requests.Expense;
using FluentValidation;

namespace Application.UseCase.Expense.Update;

public class UpdateExpenseValidator : AbstractValidator<RequestUpdateExpenseJson>
{

    public UpdateExpenseValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty()
            .WithMessage("Título não é válido.");
        
        RuleFor(prop => prop.Amount)
            .GreaterThan(decimal.Zero)
            .WithMessage("Valor deve ser maior que zero.");
        
        RuleFor(prop => prop.MovementAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Data de movimentação deve ser retroativa.");
    }
}