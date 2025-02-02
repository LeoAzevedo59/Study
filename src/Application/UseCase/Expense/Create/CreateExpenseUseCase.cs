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
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        
        if(titleIsEmpty)
            throw new ArgumentException("Title is required.");
        
        if(request.Amount <= decimal.Zero)
            throw new ArgumentException("Amount is required.");

        var result = DateTime.Compare(request.MovementAt, DateTime.UtcNow);
        if(result > 0)
            throw new ArgumentException("MovementAt must be greater than date.");

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        
        if(!paymentTypeIsValid)
            throw new ArgumentException("PaymentType is not valid.");
    }
}