using AutoMapper;
using Communication.Requests.Expense;
using Domain.Repositories;
using Domain.Repositories.Expenses;
using Exception.Exceptions;
using FluentValidation.Results;

namespace Application.UseCase.Expense.Update
{
    internal class UpdateExpenseUseCase(
        IMapper mapper,
        IExpenseUpdateOnlyRepository expenseUpdateOnlyRepository,
        IUnityOfWork unityOfWork) : IUpdateExpenseUseCase
    {
        public async Task Execute(Guid expenseId,
            RequestUpdateExpenseJson request)
        {
            Validate(request);

            Domain.Entities.Expense? expense =
                await expenseUpdateOnlyRepository.GetById(expenseId);

            if (expense is null)
            {
                throw new NotFoundException("Despesa não encontrada.",
                    "Valide o identificador da despesa.");
            }

            Domain.Entities.Expense? entity = mapper.Map(request, expense);
            expenseUpdateOnlyRepository.Update(entity);

            await unityOfWork.Commit();
        }

        private void Validate(RequestUpdateExpenseJson request)
        {
            UpdateExpenseValidator validator = new();
            ValidationResult? result = validator.Validate(request);

            List<string>? errorMessages = result
                .Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            if (!result.IsValid)
            {
                throw new ErrorOnValidationException(errorMessages,
                    "Valide os campos obrigatórios.");
            }
        }
    }
}
