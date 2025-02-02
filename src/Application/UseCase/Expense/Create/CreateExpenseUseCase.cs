using Communication.Enums;
using Communication.Requests.Expense;
using Communication.Responses.Expense;

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
    }
}