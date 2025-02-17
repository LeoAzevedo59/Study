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
        [InlineData("leo@example")] // Falta o TLD (exemplo: .com, .org)
        [InlineData("leo@example.")] // O domínio não pode terminar com um ponto
        [InlineData("leo@.com")] // Falta o nome do domínio após o "@"
        [InlineData("leo@.")] // O domínio não pode começar com um ponto
        [InlineData("leo@@example")] // Dois sinais de "@" não são permitidos
        [InlineData(
            "leo@@example.com")] // Dois sinais de "@" não são permitidos
        [InlineData("@example")] // Falta o nome do usuário antes do "@"
        [InlineData(
            "leo.com")] // Falta o "@" separando o nome de usuário e domínio
        [InlineData(
            "leo@com")] // TLD inválido (precisa ser algo como .com, .org, etc.)
        [InlineData("leo@exa mple.com")] // Espaço não permitido no e-mail
        [InlineData(
            "leo@ex!ample.com")] // Caracteres especiais inválidos no domínio
        [InlineData(
            "leo@.example.com")] // O domínio não pode começar com um ponto
        [InlineData("leo@sub_domain.com")] // O subdomínio não pode conter "_"
        [InlineData(
            "leo.@example.com")] // O nome do usuário não pode terminar com "."
        [InlineData(
            ".leo@example.com")] // O nome do usuário não pode começar com "."
        [InlineData("leo@exam_ple.com")] // O domínio não pode conter "_"
        [InlineData("leo@-example.com")] // O domínio não pode começar com "-"
        [InlineData(
            "leo@example-.com")] // O domínio não pode terminar com "-"
        [InlineData(
            "leo@ex..ample.com")] // Dois pontos seguidos não são permitidos no domínio
        [InlineData("leo@exampl#e.com")] // O domínio não pode conter "#"
        [InlineData("leo@ex*mple.com")] // O domínio não pode conter "*"
        [InlineData("leo@")] // Falta o domínio após "@"
        [InlineData(
            "leo@example..com")] // Dois pontos seguidos no TLD não são permitidos
        [InlineData("leo@example.com ")] // Espaço no final é inválido
        [InlineData(" leo@example.com")] // Espaço no início é inválido
        [InlineData(
            "leo@ex...ample.com")] // Mais que um pontos seguidos não são permitidos no domínio
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
