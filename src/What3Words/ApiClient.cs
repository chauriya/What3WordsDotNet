using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace What3Words
{
    internal class ApiClient
    {
        private static readonly string ApiBaseUrl = "https://api.what3words.com/v2/";
        private static string _apiKey;
        private static HttpClient _httpClient;

        public ApiClient(string apiKey)
        {
            _apiKey = apiKey ?? throw new NullReferenceException("API key must not be null");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
        }

        public async Task<ReverseGeocodeResponse> Reverse(double lat, double lng)
        {
            var response = await _httpClient.GetAsync($"reverse?coords={lat},{lng}&display=full&format=json&key={_apiKey}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReverseGeocodeResponse>(content);
        }
    }
}
