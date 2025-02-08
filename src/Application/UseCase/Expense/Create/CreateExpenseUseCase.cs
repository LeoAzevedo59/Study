
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Domain.Enums;
using Exception.Exceptions;
using Infra.DataAccess;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseUseCase
{
    public ResponseCreateExpenseJson Execute(RequestCreateExpenseJson request)
    {
        Validate(request);
        
        var dbContext = new ApiDbContext();

        var entity = new Domain.Entities.Expense()
        {
            Title = request.Title,
            Description = request.Description,
            MovementAt = request.MovementAt,
            Amount = request.Amount,
            PaymentType = (PaymentType)request.PaymentType,
        };
                
        dbContext.Expenses.Add(entity);
        dbContext.SaveChanges();
        
        return new()
        {
            Title = request.Title
        };
    }

    private void Validate(RequestCreateExpenseJson request)
    {
        CreateExpenseValidator validator = new();
        var result = validator.Validate(request);
        var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

        if (!result.IsValid)
            throw new ErrorOnValidationException(errorMessages);
    }
}