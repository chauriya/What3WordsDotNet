using System;
using System.Threading.Tasks;

namespace What3Words
{
    public class What3Words : IWhat3Words
    {
        private readonly string _apikey;
        private static ApiClient _apiClient;

        public What3Words(string apiKey)
        {
            _apikey = apiKey ?? throw new NullReferenceException("API key must not be null");
            _apiClient = new ApiClient(apiKey);
        }

        public async Task<ReverseGeocodeResponse> ReverseGeocode(double lat, double lng)
        {
            return await _apiClient.Reverse(lat, lng);
        }
    }
}
