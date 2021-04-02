using LACE.Core.Configuration;

namespace LACE.Adapters.RaspberryPi.Configuration
{
    public class GpioPinAdapterConfiguration : MeterAdapterConfiguration
    {
        public int PinNumber { get; set; }
        public string ScriptUri { get; set; }
    }
}
 