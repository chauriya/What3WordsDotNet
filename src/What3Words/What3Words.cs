using System.Threading.Tasks;

namespace What3Words
{
    public class What3Words : IWhat3Words
    {
        private static ApiClient _apiClient;

        public What3Words(string apiKey)
        {
            _apiClient = new ApiClient(apiKey);
        }

        public async Task<What3WordsResponse> ForwardGeocode(string firstWord, string secondWord, string thirdWord)
        {
            return await _apiClient.Forward(firstWord, secondWord, thirdWord);
        }

        public async Task<What3WordsResponse> ReverseGeocode(double lat, double lng)
        {
            return await _apiClient.Reverse(lat, lng);
        }
    }
}
