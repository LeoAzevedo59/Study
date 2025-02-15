using System.Text.Json.Serialization;

namespace Communication.Responses.User
{
    public class ResponseUserAuthJson
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = string.Empty;
    }
}
