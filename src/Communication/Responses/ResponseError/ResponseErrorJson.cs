using System.Net;
using System.Text.Json.Serialization;

namespace Communication.Responses.ResponseError;

public class ResponseErrorJson
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("message")]
    public List<string> Message { get; set; }
    
    [JsonPropertyName("action")]
    public string Action { get; set; }

    [JsonPropertyName("status_code")]
    public HttpStatusCode StatusCode { get; set; }

    public ResponseErrorJson(string name, string message, string action, HttpStatusCode statusCode)
    {
        Name = name;
        Message = [message];
        Action = action;
        StatusCode = statusCode;
    }

    public ResponseErrorJson(string name, List<string> message, string action, HttpStatusCode statusCode)
    {
        Name = name;
        Message = message;
        Action = action;
        StatusCode = statusCode;
    }
}