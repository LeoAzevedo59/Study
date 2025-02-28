using CommonTestUtilities.Requests.Expanse;
using Communication.Requests.Expense;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace Api.Tests.Controllers.Expense
{
    public class
        ExpenseCreateControllerTest : IClassFixture<CustomWebApplicationFactory>
    {
        private const string EndPoint = "api/expenses";
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _outputHelper;

        private readonly RequestCreateExpenseJson _request =
            RequestCreateExpenseJsonBuilder.Build();

        private readonly string _token;

        public ExpenseCreateControllerTest(
            CustomWebApplicationFactory webApplicationFactory,
            ITestOutputHelper outputHelper)
        {
            _httpClient = webApplicationFactory.CreateClient();
            _token = webApplicationFactory.GetToken();
            _outputHelper = outputHelper;
        }

        [Fact]
        public async Task CreateExpense_Success_ValidFields()
        {
            // Arrange
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            // Act
            HttpResponseMessage result =
                await _httpClient.PostAsJsonAsync(EndPoint, _request);

            _outputHelper.WriteLine(await result.Content.ReadAsStringAsync());

            // Assert
            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
