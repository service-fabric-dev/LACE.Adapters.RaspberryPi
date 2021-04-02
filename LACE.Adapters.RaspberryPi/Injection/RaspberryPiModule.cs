using LACE.Adapters.RaspberryPi.Meters;
using LACE.Core.Abstractions.Injection;
using LACE.Core.Abstractions.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace LACE.Adapters.RaspberryPi.Injection
{
    public class RaspberryPiModule : IModule
    {
        public void Register(IServiceCollection services)
        {
            Pi.Init<BootstrapWiringPi>();

            services.AddScoped(_ => Pi.Gpio);
            services.AddScoped<Func<int, IGpioPin>>(sp =>
                pinNumber => sp.GetService<IGpioController>()?[pinNumber]);
            services.AddScoped<IMeterAdapter, PinReader>();
            services.AddScoped<IMachineAdapter, PinWriter>();
        }
    }
}
