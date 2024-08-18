using System.Text.Json.Serialization;

namespace DatingApi.Models
{
    public class TelegramUser
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

    }
}
