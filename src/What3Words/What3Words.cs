using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace What3Words
{
    public class What3Words : IWhat3Words
    {
        private const string ApiBaseUrl = "https://api.what3words.com/v3/";
        private static HttpClient _httpClient;

        public What3Words(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new NullReferenceException("API key must not be null");
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        }

        public async Task<What3WordsResponse> ConvertToCoordinates(string firstWord, string secondWord, string thirdWord)
        {
            var response = await _httpClient.GetAsync($"convert-to-coordinates?words={firstWord}.{secondWord}.{thirdWord}");
            if (!response.IsSuccessStatusCode)
                HandleUnsuccessfulResponse(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<What3WordsResponse>(json);
        }

        public async Task<What3WordsResponse> ConvertTo3wa(double lat, double lng)
        {
            var response = await _httpClient.GetAsync($"convert-to-3wa?coordinates={lat},{lng}");
            if (!response.IsSuccessStatusCode)
                HandleUnsuccessfulResponse(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<What3WordsResponse>(json);
        }
        private static void HandleUnsuccessfulResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException("The API key is invalid");
            }
        }
    }
}
