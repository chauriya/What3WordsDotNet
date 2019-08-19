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

        public async Task<What3WordsResponse> ConvertToCoordinates(string firstWord, string secondWord, string thirdWord)
        {
            return await _apiClient.ConvertToCoordinates(firstWord, secondWord, thirdWord);
        }

        public async Task<What3WordsResponse> ConvertTo3wa(double lat, double lng)
        {
            return await _apiClient.ConvertTo3wa(lat, lng);
        }
    }
}
