using Shouldly;
using Xunit;

namespace What3Words.Test
{
    public class What3WordsShould
    {
        private readonly string ApiKey = "<Your API key here>";

        [Fact]
        public async void ReturnCorrectReverseGeocodeResponse()
        {
            var w3w = new What3Words(ApiKey);

            var result = await w3w.ReverseGeocode(42.998737, -81.254357);

            result.ToString().ShouldBe("offshore.bitters.voltage");
            result.Map.ShouldBe("http://w3w.co/offshore.bitters.voltage");
        }
    }
}
