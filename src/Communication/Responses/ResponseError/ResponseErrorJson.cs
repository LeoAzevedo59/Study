using System.Net;

namespace Communication.Responses.ResponseError
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(string name, string message, string action,
            HttpStatusCode statusCode)
        {
            Name = name;
            Message = [message];
            Action = action;
            StatusCode = statusCode;
        }

        public ResponseErrorJson(string name, List<string> message,
            string action, HttpStatusCode statusCode)
        {
            Name = name;
            Message = message;
            Action = action;
            StatusCode = statusCode;
        }

        public string Name { get; init; }
        public List<string> Message { get; init; }
        public string Action { get; init; }
        public HttpStatusCode StatusCode { get; init; }
    }
}
