using LACE.Adapters.RaspberryPi.Configuration;
using LACE.Core.Abstractions.Model;
using LACE.Core.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO.Abstractions;

namespace LACE.Adapters.RaspberryPi.Meters
{
    public class PinWriter: IMachineAdapter
    {
        private readonly GpioPinAdapterConfiguration _config;
        private readonly Func<int, IGpioPin> _pinFactory;

        public PinWriter(
            Func<int, IGpioPin> pinFactory,
            GpioPinAdapterConfiguration config)
        {
            _pinFactory = pinFactory.Guard(nameof(pinFactory));
        }

        private int PinNumber => _config.PinNumber;
        private IGpioPin Pin => _pinFactory(PinNumber);
        
        public Task WorkAsync(IFacts facts, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
