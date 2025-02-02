using Communication.Enums;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Exception.Exceptions;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseUseCase
{
    public ResponseCreateExpenseJson Execute(RequestCreateExpenseJson request)
    {
        Validate(request);
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