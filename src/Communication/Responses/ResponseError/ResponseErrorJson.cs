using System.Net;
using System.Text.Json.Serialization;

namespace Communication.Responses.ResponseError;

public class ResponseErrorJson
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("message")]
    public required string Message { get; set; }
    
    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("status_code")]
    public required HttpStatusCode StatusCode { get; set; }
}