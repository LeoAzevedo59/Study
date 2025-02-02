using Communication.Requests.Expense;
using FluentValidation;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseValidator : AbstractValidator<RequestCreateExpenseJson>
{
    public CreateExpenseValidator()
    {
        RuleFor(prop => prop.Title).NotEmpty()
            .WithMessage("Título não é válido.");
        
        RuleFor(prop => prop.Amount).GreaterThan(decimal.Zero)
            .WithMessage("Valor deve ser maior que zero.");
        
        RuleFor(prop => prop.MovementAt).LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Data de movimentação deve ser retroativa.");

        RuleFor(prop => prop.PaymentType).IsInEnum()
            .WithMessage("Tipo de pagamento não é válido.");
    }
}