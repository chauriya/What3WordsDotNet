using System.Threading.Tasks;

namespace What3Words
{
    public interface IWhat3Words
    {
        Task<ThreeWordAddress> ReverseGeocode(double lat, double lng);
    }
}
