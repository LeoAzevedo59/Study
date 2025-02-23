using CommonTestUtilities.Requests.User;
using Communication.Requests.Users;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace Api.Tests.Users.Create
{
    public class CreateUserTest(WebApplicationFactory<Program> factory)
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private const string EndPoint = "api/users";

        private readonly HttpClient _httpClient = factory.CreateClient();

        private readonly RequestCreateUserJson _request =
            RequestCreateUserJsonBuilder.Build();

        [Fact]
        public async Task UserCreate_Success_ValidFields()
        {
            _request.Email = "test2@test.com";

            Uri? url = _httpClient.BaseAddress;

            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            Assert.True(result.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }
    }
}
