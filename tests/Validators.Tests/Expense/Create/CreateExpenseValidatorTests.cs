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
        // Arrange: Preparação
        CreateExpenseValidator validator = new();
        var request = RequestCreateExpenseJsonBuilder.Build();

        // Act: Ação 
        var result = validator.Validate(request);

        // Assert: Verificação
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("  ")]
    [InlineData("")]
    public void Error_Title_Invalid(string title)
    {
        CreateExpenseValidator validator = new();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Title = title;

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Error_Amount_Invalid(decimal amount)
    {
        CreateExpenseValidator validator = new();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Amount = amount;

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Single(result.Errors);

    }

    [Fact]
    public void Errors_Multiple_Props_Invalid()
    {
        int PROPS_WITH_ERRORS = 4;

        CreateExpenseValidator validator = new();
        var request = RequestCreateExpenseJsonBuilder.Build();
        request.Title = "   ";
        request.Amount = -1;
        request.MovementAt = DateTime.UtcNow.AddDays(1);
        request.PaymentType = (PaymentType)999;

        var result = validator.Validate(request);
        int listLenght = result.Errors.Count;

        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
        Assert.Equal(PROPS_WITH_ERRORS, listLenght);
        Assert.Equal("Título não é válido.", result.Errors[0].ErrorMessage);
        Assert.Equal("Valor deve ser maior que zero.", result.Errors[1].ErrorMessage);
        Assert.Equal("Data de movimentação deve ser retroativa.", result.Errors[2].ErrorMessage);
        Assert.Equal("Tipo de pagamento não é válido.", result.Errors[3].ErrorMessage);
    }
}

