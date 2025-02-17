using Application.UseCase.User.Create;
using CommonTestUtilities.Requests.User;
using Communication.Requests.Users;
using FluentValidation.Results;

namespace Validators.Tests.User
{
    public class CreateUserValidatorTests
    {
        [Fact]
        public void UserCreate_Success_ValidFields()
        {
            // Arrange: Preparação
            CreateUserValidator validator = new();
            RequestCreateUserJson
                request = RequestCreateUserJsonBuilder.Build();

            // Act: Ação
            ValidationResult? result = validator.Validate(request);

            // Assert: Verificação
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("leo@example")]
        [InlineData("leo@example.")]
        [InlineData("leo@.com")]
        [InlineData("leo@.")]
        [InlineData("leo@@example")]
        [InlineData("leo@@example.com")]
        [InlineData("@example")]
        [InlineData("leo.com")]
        public void UserCreate_Error_EmailInvalid(string email)
        {
            CreateUserValidator validator = new();
            RequestCreateUserJson? request =
                RequestCreateUserJsonBuilder.Build();
            request.Email = email;

            ValidationResult? result = validator.Validate(request);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UserCreate_Success_Exceeded_FirstCharacterLimit()
        {
            CreateUserValidator validator = new();
            RequestCreateUserJson? request =
                RequestCreateUserJsonBuilder.Build();
            request.Email =
                "leoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleoleole@exemple.com";

            ValidationResult? result = validator.Validate(request);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UserCreate_Success_Exceeded_LastCharacterLimit()
        {
            CreateUserValidator validator = new();
            RequestCreateUserJson? request =
                RequestCreateUserJsonBuilder.Build();
            request.Email =
                "leo@exempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexempleexemplll.com";

            ValidationResult? result = validator.Validate(request);

            Assert.False(result.IsValid);
        }
    }
}
