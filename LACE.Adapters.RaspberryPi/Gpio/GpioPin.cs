using System;
using LACE.Core.Extensions;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace LACE.Adapters.RaspberryPi.Gpio
{
    public class GpioPin
    {
        private readonly Func<int,IGpioPin> _pinFactory;

        public GpioPin(Func<int, IGpioPin> pinFactory)
        {
            _pinFactory = pinFactory.Guard(nameof(pinFactory));
        }

        public void Read(int pinNumber)
        {
            Pi.Init<BootstrapWiringPi>();

            var pin = _pinFactory(pinNumber);

            pin.PinMode = GpioPinDriveMode.Output;

        }
    }
}
