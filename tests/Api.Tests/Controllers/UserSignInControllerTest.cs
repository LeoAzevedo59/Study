using CommonTestUtilities.Requests.User;
using Communication.Requests.Users;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit.Abstractions;

namespace Api.Tests.Controllers
{
    public class
        UserSignInControllerTest : IClassFixture<CustomWebApplicationFactory>
    {
        private const string EndPoint = "api/auth/sign-in";

        private readonly string _email;
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _outputHelper;

        private readonly RequestSigninUserJson _request =
            RequestSignInUserJsonBuilder.Build();

        public UserSignInControllerTest(
            CustomWebApplicationFactory webApplicationFactory,
            ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _httpClient = webApplicationFactory.CreateClient();
            _email = webApplicationFactory.GetEmail();
        }

        [Fact]
        public async Task UserSignIn_Success_ValidFields()
        {
            // Arrange
            _request.Email = _email;

            // Act
            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);


            // Assert
            string bodyResponse = await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? accessToken = response.RootElement
                .GetProperty("access_token").GetString();

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.NotNull(accessToken);
            Assert.NotEmpty(accessToken);
        }

        [Fact]
        public async Task UserSignIn_Failed_EmailEmpty()
        {
            // Arrange
            _request.Email = string.Empty;

            // Act

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            _outputHelper.WriteLine(await result.Content.ReadAsStringAsync());

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? errorName =
                response.RootElement.GetProperty("name").GetString();

            string? errorAction =
                response.RootElement.GetProperty("action").GetString();

            int statusCode =
                response.RootElement.GetProperty("status_code").GetInt16();

            JsonElement.ArrayEnumerator errorMessages = response.RootElement
                .GetProperty("message")
                .EnumerateArray();

            List<string> messages = response.RootElement
                .GetProperty("message")
                .EnumerateArray()
                .Select(element => element.GetString()!)
                .ToList();

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            Assert.Equal("ErrorOnValidationException", errorName);
            Assert.Equal("Preencha um e-mail válido.", errorAction);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)statusCode);

            Assert.Single(errorMessages);
            Assert.Contains("E-mail é obrigatório.", messages);
        }

        [Fact]
        public async Task UserSignIn_Failed_PasswordEmpty()
        {
            // Arrange
            _request.Email = _email;
            _request.Password = string.Empty;

            // Act

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            _outputHelper.WriteLine(await result.Content.ReadAsStringAsync());

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? errorName =
                response.RootElement.GetProperty("name").GetString();

            string? errorAction =
                response.RootElement.GetProperty("action").GetString();

            int statusCode =
                response.RootElement.GetProperty("status_code").GetInt16();

            JsonElement.ArrayEnumerator errorMessages = response.RootElement
                .GetProperty("message")
                .EnumerateArray();

            List<string> messages = response.RootElement
                .GetProperty("message")
                .EnumerateArray()
                .Select(element => element.GetString()!)
                .ToList();

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            Assert.Equal("ErrorOnValidationException", errorName);
            Assert.Equal("Preencha uma senha.", errorAction);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)statusCode);

            Assert.Single(errorMessages);
            Assert.Contains("Senha é obrigatório.", messages);
        }

        [Fact]
        public async Task UserSignIn_Failed_UserNotFound()
        {
            // Arrange
            _request.Email = "email_diferente@email.com";

            // Act

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            _outputHelper.WriteLine(await result.Content.ReadAsStringAsync());

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? errorName =
                response.RootElement.GetProperty("name").GetString();

            string? errorAction =
                response.RootElement.GetProperty("action").GetString();

            int statusCode =
                response.RootElement.GetProperty("status_code").GetInt16();

            JsonElement.ArrayEnumerator errorMessages = response.RootElement
                .GetProperty("message")
                .EnumerateArray();

            List<string> messages = response.RootElement
                .GetProperty("message")
                .EnumerateArray()
                .Select(element => element.GetString()!)
                .ToList();

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            Assert.Equal("ErrorOnValidationException", errorName);
            Assert.Equal("Caso não lembre a senha redefina sua senha.",
                errorAction);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)statusCode);

            Assert.Single(errorMessages);
            Assert.Contains("E-mail e/ou senha incorreto(s).", messages);
        }

        [Fact]
        public async Task UserSignIn_Failed_PasswordNotMatch()
        {
            // Arrange
            _request.Password = "Senha diferente";

            // Act

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            _outputHelper.WriteLine(await result.Content.ReadAsStringAsync());

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? errorName =
                response.RootElement.GetProperty("name").GetString();

            string? errorAction =
                response.RootElement.GetProperty("action").GetString();

            int statusCode =
                response.RootElement.GetProperty("status_code").GetInt16();

            JsonElement.ArrayEnumerator errorMessages = response.RootElement
                .GetProperty("message")
                .EnumerateArray();

            List<string> messages = response.RootElement
                .GetProperty("message")
                .EnumerateArray()
                .Select(element => element.GetString()!)
                .ToList();

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            Assert.Equal("ErrorOnValidationException", errorName);
            Assert.Equal("Caso não lembre a senha redefina sua senha.",
                errorAction);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)statusCode);

            Assert.Single(errorMessages);
            Assert.Contains("E-mail e/ou senha incorreto(s).", messages);
        }
    }
}
