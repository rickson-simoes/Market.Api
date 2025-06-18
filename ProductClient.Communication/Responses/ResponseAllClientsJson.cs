using System.Text.Json.Serialization;

namespace ProductClient.Communication.Responses
{
    public class ResponseAllClientsJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
