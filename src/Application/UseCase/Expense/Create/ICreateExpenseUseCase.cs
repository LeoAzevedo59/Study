using Communication.Requests.Expense;
using Communication.Responses.Expense;

namespace Application.UseCase.Expense.Create;

public interface ICreateExpenseUseCase
{
    Task<ResponseCreateExpenseJson> Execute(RequestCreateExpenseJson request);
}