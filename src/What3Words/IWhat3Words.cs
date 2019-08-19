using System.Threading.Tasks;

namespace What3Words
{
    public interface IWhat3Words
    {
        Task<What3WordsResponse> ConvertToCoordinates(string firstWord, string secondWord, string thirdWord);
        Task<What3WordsResponse> ConvertTo3wa(double lat, double lng);
    }
}
