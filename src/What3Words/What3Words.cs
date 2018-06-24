using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace What3Words
{
    public class What3Words : IWhat3Words
    {
        private readonly string _apikey;
        private static readonly string BaseUrl = "https://api.what3words.com/v2/";
        private static HttpClient _httpClient;

        public What3Words(string apiKey)
        {
            _apikey = apiKey ?? throw new NullReferenceException("API key must not be null");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<ThreeWordAddress> ReverseGeocode(double lat, double lng)
        {
            var response = await _httpClient.GetAsync($"reverse?coords={lat},{lng}&display=full&format=json&key={_apikey}");
            var content = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<ForwardGeocodeResponse>(content);
            var words = model.words.Split('.');
            return new ThreeWordAddress(words[0], words[1], words[2]);
        }
    }
}
