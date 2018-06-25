using Shouldly;
using System;
using Xunit;

namespace What3Words.Test
{
    public class What3WordsShould
    {
        private readonly string ApiKey = "<Your API key here>";

        [Fact]
        public async void ForwardGeocodeResponse()
        {
            var w3w = new What3Words(ApiKey);

            var result = await w3w.ForwardGeocode("offshore", "bitters", "voltage");

            result.ToString().ShouldBe("offshore.bitters.voltage");
            result.Map.ShouldBe("http://w3w.co/offshore.bitters.voltage");
            result.Geometry.Lat.ShouldBe(42.998747);
            result.Geometry.Lng.ShouldBe(-81.254366);
        }

        [Fact]
        public async void ReturnCorrectReverseGeocodeResponse()
        {
            var w3w = new What3Words(ApiKey);

            var result = await w3w.ReverseGeocode(42.998747, -81.254366);

            result.ToString().ShouldBe("offshore.bitters.voltage");
            result.Map.ShouldBe("http://w3w.co/offshore.bitters.voltage");
        }

        [Fact]
        public async void ThrowExceptionDueToInvalidApiKey()
        {
            const string invalidApiKey = "This shouldn't work";
            var w3w = new What3Words(invalidApiKey);

            Should.Throw<UnauthorizedAccessException>(async () => await w3w.ReverseGeocode(42.998737, -81.254357))
                .Message.ShouldBe("The API key is invalid");
        }
    }
}
