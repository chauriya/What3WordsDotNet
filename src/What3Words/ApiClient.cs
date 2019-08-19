using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace What3Words
{
    internal class ApiClient
    {
        private const string ApiBaseUrl = "https://api.what3words.com/v3/";
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

        public async Task<What3WordsResponse> ConvertToCoordinates(string firstWord, string secondWord, string thirdWord)
        {
            var response = await _httpClient.GetAsync($"convert-to-coordinates?words={firstWord}.{secondWord}.{thirdWord}&key={_apiKey}");
            if (!response.IsSuccessStatusCode)
                HandleUnsuccessfulResponse(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<What3WordsResponse>(json);
        }

        public async Task<What3WordsResponse> ConvertTo3wa(double lat, double lng)
        {
            var response = await _httpClient.GetAsync($"convert-to-3wa?coordinates={lat},{lng}&key={_apiKey}");
            if (!response.IsSuccessStatusCode)
                HandleUnsuccessfulResponse(response);
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<What3WordsResponse>(json);
        }

        private void HandleUnsuccessfulResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException("The API key is invalid");
        }
    }
}
