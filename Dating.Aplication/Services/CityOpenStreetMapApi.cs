using Dating.Aplication.Interfaces;
using System.Globalization;
using System.Text.Json;

namespace Dating.Aplication.Services
{
    public class CityOpenStreetMapApi : ICityApi
    {
        public async Task<string> GetCityName(double latitude, double longitude)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=geocodejson&lat={latitude.ToString(new NumberFormatInfo { NumberDecimalSeparator = "." })}&lon={longitude.ToString(new NumberFormatInfo { NumberDecimalSeparator = "." })}&addressdetails=1";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("C# App"); // Установите user-agent

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var dic = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonResponse);
                    if (dic != null)
                    {
                        var address = dic["address"];
                        if (address != null)
                        {
                            var addressDic = JsonSerializer.Deserialize<Dictionary<string, string>>(address);
                            if (addressDic != null)
                            {
                                var city = addressDic["city"] ?? addressDic["town"] ?? addressDic["village"];
                                if (city != null)
                                {
                                    return city;
                                }
                            }
                        }
                    }
                }

                throw new Exception();
            }
        }
    }
}
