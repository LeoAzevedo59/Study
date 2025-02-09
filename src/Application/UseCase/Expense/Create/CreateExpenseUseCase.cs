using AutoMapper;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Domain.Enums;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;
using ExpenseEntity = Domain.Entities.Expense;

namespace Application.UseCase.Expense.Create;

public class CreateExpenseUseCase(
    IExpenseWriteOnlyRepository expenseRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork) : ICreateExpenseUseCase
{
    public async Task<ResponseCreateExpenseJson> Execute(RequestCreateExpenseJson request)
    {
        Validate(request);

        var entity = mapper.Map<ExpenseEntity>(request);
        
        await expenseRepository.Add(entity);
        await  unityOfWork.Commit();
        
        var response = mapper.Map<ResponseCreateExpenseJson>(entity);

        return response;
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
            throw new ErrorOnValidationException(errorMessages, "Valide os campos obrigatórios.");
    }
}