using Application.UseCase.Expense.Create;
using CommonTestUtilities.Requests.Expanse;
using Communication.Enums;
using Communication.Requests.Expense;

namespace Validators.Tests.Expense.Create;

public class CreateExpenseValidatorTests
{
    [Fact]
    public void Success()   // nome do restulado esperado
    {
     // Arrange : Preparação
     CreateExpenseValidator validator = new();
     var request = new RequestCreateExpenseJsonBuilder().Build();
     
     // Act : Ação 
     var result = validator.Validate(request);

     // Assert : Verificação
     Assert.True(result.IsValid);
    }
}