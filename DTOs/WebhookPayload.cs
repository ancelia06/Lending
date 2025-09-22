using System.Text.Json.Serialization;

namespace Lending_CapstoneProject.DTOs
{
    public class WebhookPayload
    {
        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("payload")]
        public object Payload { get; set; }



    }
}
