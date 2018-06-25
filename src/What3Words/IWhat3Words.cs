using System.Threading.Tasks;

namespace What3Words
{
    public interface IWhat3Words
    {
        Task<What3WordsResponse> ForwardGeocode(string firstWord, string secondWord, string thirdWord);
        Task<What3WordsResponse> ReverseGeocode(double lat, double lng);
    }
}
