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
    }
}
