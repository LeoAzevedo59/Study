
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Domain.Enums;
using Domain.Repositories.Expenses;
using Exception.Exceptions;
using ExpenseEntity = Domain.Entities.Expense;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseUseCase(IExpenseRepository expenseRepository) : ICreateExpenseUseCase
{
    public ResponseCreateExpenseJson Execute(RequestCreateExpenseJson request)
    {
        Validate(request);

        var entity = new ExpenseEntity()
        {
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            MovementAt = request.MovementAt,
            Payment = (PaymentType)request.PaymentType
        };
        
        expenseRepository.Add(entity);
        
        return new()
        {
            Title = entity.Title
        };
    }

    private void Validate(RequestCreateExpenseJson request)
    {
        CreateExpenseValidator validator = new();
        var result = validator.Validate(request);
        var errorMessages = result
            .Errors
            .Select(error => error.ErrorMessage)
            .ToList();

        if (!result.IsValid)
            throw new ErrorOnValidationException(errorMessages);
    }
}