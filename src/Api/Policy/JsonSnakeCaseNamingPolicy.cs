using System.Text.Json;

namespace Api.Policy
{
    public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return string.Concat(name.Select((c, i) =>
                i > 0 && char.IsUpper(c) ? "_" + c : c.ToString())).ToLower();
        }
    }
}
