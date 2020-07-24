using LACE.Adapters.RaspberryPi.Meters;
using Xunit;

namespace LACE.Adapters.RaspberryPi.UnitTests
{
    public class GpioPinTests : EmbeddedTest
    {
        private static readonly string _scriptUri = ContentLoader.LoadJson<string>();

        [Theory]
        [InlineData(1, 0.3)]
        public void ReadValue_ValueReturned(int pinPosition, decimal expected)
        {
            var pin = new GpioPinAdapter(pinPosition, _scriptUri);

            Assert.Equal(expected, pin.Value);
        }
    }
}
