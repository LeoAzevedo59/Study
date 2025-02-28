using Communication.Requests.Expense;
using Communication.Responses.Expense;
using Communication.Utils;
using Domain.Enums;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.Expense.Create
{
    internal class CreateExpenseUseCase(
        IExpenseWriteOnlyRepository expenseRepository,
        IUnityOfWork unityOfWork) : ICreateExpenseUseCase
    {
        public async Task<ResponseCreateExpenseJson> Execute(
            RequestCreateExpenseJson request)
        {
            Guid userId = Guid.Parse("378edde3-84eb-4137-93df-76bf62ff3b1e");

            Validate(request);

            Domain.Entities.Expense entity =
                new(request.Title, request.Description,
                    request.MovementAt, request.Amount,
                    (PaymentType)request.PaymentType,
                    userId);

            await expenseRepository.Add(entity);
            await unityOfWork.Commit();

            ResponseCreateExpenseJson response = new(entity.Title);

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
