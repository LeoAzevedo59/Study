using System.Text.Json.Serialization;

namespace Communication.Responses.User
{
    public class ResponseCreateUserJson
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;
    }
}
