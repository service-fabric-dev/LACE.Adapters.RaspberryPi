using System;
using System.Threading;
using System.Threading.Tasks;
using LACE.Adapters.RaspberryPi.Configuration;
using LACE.Adapters.RaspberryPi.Meters;
using LACE.Core.Configuration;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Xunit;

namespace LACE.Adapters.RaspberryPi.UnitTests
{
    public class GpioPinTests : EmbeddedTest
    {
        private static readonly DefaultServiceConfiguration _config = ContentLoader.LoadJson<DefaultServiceConfiguration>("service-configuration.json");
        private static IGpioPin PinFactory(int pinNumber) => Pi.Gpio[pinNumber];

        [Theory]
        [InlineData(1, 0.3)]
        public async Task ReadValue_ValueReturned(int pinPosition, float expected)
        {
            var adapterConfig = _config.AdapterConfigs.MeterAdapters.Adapters
                .Find(m => m is GpioPinAdapterConfiguration) as GpioPinAdapterConfiguration;

            var config = new GpioPinAdapterConfiguration
            {
                PinNumber = pinPosition,
                ScriptUri = "E:/source/repos/LACE.Adapters.RaspberryPi/LACE.Adapters.RaspberryPi/Gpio/PinReader.py"
            };


            var pin = new PinReader(PinFactory, config);
            var result = await pin.ReadAsync(CancellationToken.None);
            Assert.NotNull(result);
        }
    }
}
