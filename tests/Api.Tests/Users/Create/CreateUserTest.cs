using CommonTestUtilities.Requests.User;
using Communication.Requests.Users;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Api.Tests.Users.Create
{
    public class CreateUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private const string EndPoint = "api/users";

        private readonly HttpClient _httpClient;

        private readonly RequestCreateUserJson _request =
            RequestCreateUserJsonBuilder.Build();

        public CreateUserTest(CustomWebApplicationFactory webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task UserCreate_Success_ValidFields()
        {
            // ACT
            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? accessToken = response.RootElement
                .GetProperty("access_token").GetString();

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            Assert.NotNull(accessToken);
            Assert.NotEmpty(accessToken);
        }

        [Fact]
        public async Task UserCreate_Fails_EmptyName()
        {
            // ACT
            _request.Name = "test-com-mais-de-32-caracteres-error";
            _request.Email = "test-gmail.com";
            _request.Password = string.Empty;

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            // ASSERT
            string bodyResponse =
                await result.Content.ReadAsStringAsync();

            JsonDocument response = JsonDocument.Parse(bodyResponse);

            string? name = response.RootElement
                .GetProperty("name").GetString();

            string? action = response.RootElement
                .GetProperty("action").GetString();

            int statusCode = response.RootElement
                .GetProperty("status_code").GetInt16();

            List<string> messages = response.RootElement
                .GetProperty("message")
                .EnumerateArray()
                .Select(element => element.GetString()!)
                .ToList();

            Assert.False(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            Assert.Equal("ErrorOnValidationException", name);
            Assert.Equal("Valide os campos obrigatórios.", action);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)statusCode);
            Assert.Equal(3, messages.Count);
            Assert.Contains("Nome deve conter no máximo 32 caracteres.",
                messages);
            Assert.Contains("Senha é obrigatório.", messages);
            Assert.Contains("E-mail não é válido.", messages);
        }
    }
}
