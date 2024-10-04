using Dating.Aplication.Interfaces;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dating.Aplication.Services
{
    public class CityOpenStreetMapApi : ICityApi
    {
        class PlaceInfo
        {
            [JsonPropertyName("address")]
            public AddresInfo Address { get; set; }
        }

        class AddresInfo
        {
            [JsonPropertyName("city")]
            public string? City { get; set; }

            [JsonPropertyName("town")]
            public string? Town { get; set; }

            [JsonPropertyName("village")]
            public string? Village { get; set; }
        }

        public async Task<string> GetCityName(double latitude, double longitude)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={latitude.ToString(new NumberFormatInfo { NumberDecimalSeparator = "." })}&lon={longitude.ToString(new NumberFormatInfo { NumberDecimalSeparator = "." })}&addressdetails=1";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# App"); // Установите user-agent

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var place = JsonSerializer.Deserialize<PlaceInfo>(jsonResponse);
                    if (place != null)
                    {
                        var address = place.Address;
                        if (address != null)
                        {
                            var city = address.City ?? address.Town ?? address.Village;
                            if (city != null)
                            {
                                return city;
                            }
                        }
                    }
                }

                throw new Exception();
            }
        }
    }
}
