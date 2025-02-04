using Application.UseCase.Expense.Create;
using Communication.Enums;
using Communication.Requests.Expense;

namespace Validators.Tests.Expense.Create;

public class CreateExpenseValidatorTests
{
    // nome do restulado esperado
    [Fact]
    public void Success()
    {
     // Arrange : Preparação
     CreateExpenseValidator validator = new();
     RequestCreateExpenseJson request = new()
     {
        Title = "title",
        Description = "description",
        Amount = 1,
        MovementAt = DateTime.Now,
        PaymentType = PaymentType.Cash,
     };

     // Act : Ação 
     var result = validator.Validate(request);

     // Assert : Verificação
     Assert.True(result.IsValid);
    }
}