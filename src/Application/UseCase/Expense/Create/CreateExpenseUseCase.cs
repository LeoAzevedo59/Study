using AutoMapper;
using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Communication.Utils;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.Expense.Create
{
    public class CreateExpenseUseCase(
        IExpenseWriteOnlyRepository expenseRepository,
        IMapper mapper,
        IUnityOfWork unityOfWork) : ICreateExpenseUseCase
    {
        public async Task<ResponseCreateExpenseJson> Execute(
            RequestCreateExpenseJson request)
        {
            Validate(request);

            Domain.Entities.Expense? entity =
                mapper.Map<Domain.Entities.Expense>(request);

            await expenseRepository.Add(entity);
            await unityOfWork.Commit();

            ResponseCreateExpenseJson? response =
                mapper.Map<ResponseCreateExpenseJson>(entity);

            return response;
        }

        private void Validate(RequestCreateExpenseJson request)
        {
            CreateExpenseValidator validator = new();
            ValidationResult? result = validator.Validate(request);
            List<string> errorMessages =
                ErrorMessagesFilter.GetMessages(result);

            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(errorMessages,
                    "Valide os campos obrigatórios.");
            }
        }
    }
}
