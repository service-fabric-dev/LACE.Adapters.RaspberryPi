using LACE.Adapters.RaspberryPi.Configuration;
using LACE.Adapters.RaspberryPi.Facts;
using LACE.Core.Abstractions.Model;
using LACE.Core.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO.Abstractions;

namespace LACE.Adapters.RaspberryPi.Meters
{
    public class PinReader : IMeterAdapter
    {
        private readonly GpioPinAdapterConfiguration _config;
        private readonly Func<int, IGpioPin> _pinFactory;

        public PinReader(
            Func<int, IGpioPin> pinFactory,
            GpioPinAdapterConfiguration config)
        {
            _pinFactory = pinFactory.Guard(nameof(pinFactory));
        }

        private int PinNumber => _config.PinNumber;
        private IGpioPin GpioPin => _pinFactory(PinNumber);
        
        public Task<IFact> ReadAsync(CancellationToken cancellation)
        {
            // Since this may not be the only reference to the pin, restore original
            var originalMode = GpioPin.PinMode;
            GpioPin.PinMode = GpioPinDriveMode.Input;
            var value = GpioPin.Read();
            GpioPin.PinMode = originalMode;

            // TODO: Log

            return Task.FromResult<IFact>(new Fact<bool>
            {
                Observation = value
            });
        }
    }
}
